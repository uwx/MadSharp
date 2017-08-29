//Credit to Paul Bourke (pbourke@swin.edu.au) for the original Fortran 77 Program :))
//Converted to a standalone C# 2.0 library by Morten Nielsen (www.iter.dk)
//Check out: http://astronomy.swin.edu.au/~pbourke/terrain/triangulate/
//You can use this code however you like providing the above credits remain in tact

using System;
using System.Collections.Generic;

namespace Triangulator
{
	/// <summary>
	/// Performs the Delauney triangulation on a set of vertices.
	/// </summary>
	/// <remarks>
	/// Based on Paul Bourke's "An Algorithm for Interpolating Irregularly-Spaced Data
	/// with Applications in Terrain Modelling"
	/// http://astronomy.swin.edu.au/~pbourke/modelling/triangulate/
	/// </remarks>
	public class Delauney	
	{
		/// <summary>
		/// Performs Delauney triangulation on a set of points.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The triangulation doesn't support multiple points with the same planar location.
		/// Vertex-lists with duplicate points may result in strange triangulation with intersecting edges.
		/// To avoid adding multiple points to your vertex-list you can use the following anonymous predicate
		/// method:
		/// <code>
		/// if(!Vertices.Exists(delegate(Triangulator.Geometry.Point p) { return pNew.Equals2D(p); }))
		///		Vertices.Add(pNew);
		/// </code>
		/// </para>
		/// <para>The triangulation algorithm may be described in pseudo-code as follows:
		/// <code>
		/// subroutine Triangulate
		/// input : vertex list
		/// output : triangle list
		///    initialize the triangle list
		///    determine the supertriangle
		///    add supertriangle vertices to the end of the vertex list
		///    add the supertriangle to the triangle list
		///    for each sample point in the vertex list
		///       initialize the edge buffer
		///       for each triangle currently in the triangle list
		///          calculate the triangle circumcircle center and radius
		///          if the point lies in the triangle circumcircle then
		///             add the three triangle edges to the edge buffer
		///             remove the triangle from the triangle list
		///          endif
		///       endfor
		///       delete all doubly specified edges from the edge buffer
		///          this leaves the edges of the enclosing polygon only
		///       add to the triangle list all triangles formed between the point 
		///          and the edges of the enclosing polygon
		///    endfor
		///    remove any triangles from the triangle list that use the supertriangle vertices
		///    remove the supertriangle vertices from the vertex list
		/// end
		/// </code>
		/// </para>
		/// </remarks>
		/// <param name="Vertex">List of vertices to triangulate.</param>
		/// <returns>Triangles referencing vertex indices arranged in clockwise order</returns>
		public static List<Geometry.Triangle> Triangulate(List<Triangulator.Geometry.Point> Vertex)
		{
			int nv = Vertex.Count;
			if (nv < 3)
				throw new ArgumentException("Need at least three vertices for triangulation");

			int trimax = 4 * nv;

			// Find the maximum and minimum vertex bounds.
			// This is to allow calculation of the bounding supertriangle
			double xmin = Vertex[0].X;
			double ymin = Vertex[0].Y;
			double xmax = xmin;
			double ymax = ymin;
			for (int i = 1; i < nv; i++)
			{
				if (Vertex[i].X < xmin) xmin = Vertex[i].X;
				if (Vertex[i].X > xmax) xmax = Vertex[i].X;
				if (Vertex[i].Y < ymin) ymin = Vertex[i].Y;
				if (Vertex[i].Y > ymax) ymax = Vertex[i].Y;
			}

			double dx = xmax - xmin;
			double dy = ymax - ymin;
			double dmax = (dx > dy) ? dx : dy;

			double xmid = (xmax + xmin) * 0.5;
			double ymid = (ymax + ymin) * 0.5;

			
			// Set up the supertriangle
			// This is a triangle which encompasses all the sample points.
			// The supertriangle coordinates are added to the end of the
			// vertex list. The supertriangle is the first triangle in
			// the triangle list.
			Vertex.Add(new Triangulator.Geometry.Point((xmid - 2 * dmax), (ymid - dmax)));
			Vertex.Add(new Triangulator.Geometry.Point(xmid, (ymid + 2 * dmax)));
			Vertex.Add(new Triangulator.Geometry.Point((xmid + 2 * dmax), (ymid - dmax)));
			List<Geometry.Triangle> Triangle = new List<Geometry.Triangle>();
			Triangle.Add(new Geometry.Triangle(nv, nv + 1, nv + 2)); //SuperTriangle placed at index 0
			
			// Include each point one at a time into the existing mesh
			for (int i = 0; i < nv; i++)
			{
				List<Geometry.Edge> Edges = new List<Geometry.Edge>(); //[trimax * 3];
				// Set up the edge buffer.
				// If the point (Vertex(i).x,Vertex(i).y) lies inside the circumcircle then the
				// three edges of that triangle are added to the edge buffer and the triangle is removed from list.
				for (int j = 0; j < Triangle.Count; j++)
				{
					if (InCircle(Vertex[i], Vertex[Triangle[j].p1], Vertex[Triangle[j].p2], Vertex[Triangle[j].p3]))
					{
						Edges.Add(new Geometry.Edge(Triangle[j].p1, Triangle[j].p2));
						Edges.Add(new Geometry.Edge(Triangle[j].p2, Triangle[j].p3));
						Edges.Add(new Geometry.Edge(Triangle[j].p3, Triangle[j].p1));
						Triangle.RemoveAt(j);
						j--;
					}
				}
				if (i >= nv) continue; //In case we the last duplicate point we removed was the last in the array

				// Remove duplicate edges
				// Note: if all triangles are specified anticlockwise then all
				// interior edges are opposite pointing in direction.
				for (int j = Edges.Count - 2; j >= 0; j--)
				{
					for (int k = Edges.Count - 1; k >= j + 1; k--)
					{
						if (Edges[j].Equals(Edges[k]))
						{
							Edges.RemoveAt(k);
							Edges.RemoveAt(j);
							k--;
							continue;
						}
					}
				}
				// Form new triangles for the current point
				// Skipping over any tagged edges.
				// All edges are arranged in clockwise order.
				for (int j = 0; j < Edges.Count; j++)
				{
					if (Triangle.Count >= trimax)
						throw new ApplicationException("Exceeded maximum edges");
					Triangle.Add(new Geometry.Triangle(Edges[j].p1, Edges[j].p2, i));
				}
				Edges.Clear();
				Edges = null;
			}
			// Remove triangles with supertriangle vertices
			// These are triangles which have a vertex number greater than nv
			for (int i = Triangle.Count - 1; i >= 0; i--)
			{
				if (Triangle[i].p1 >= nv || Triangle[i].p2 >= nv || Triangle[i].p3 >= nv)
					Triangle.RemoveAt(i);
			}
			//Remove SuperTriangle vertices
			Vertex.RemoveAt(Vertex.Count - 1);
			Vertex.RemoveAt(Vertex.Count - 1);
			Vertex.RemoveAt(Vertex.Count - 1);
			Triangle.TrimExcess();
			return Triangle;
		}

		/// <summary>
		/// Returns true if the point (p) lies inside the circumcircle made up by points (p1,p2,p3)
		/// </summary>
		/// <remarks>
		/// NOTE: A point on the edge is inside the circumcircle
		/// </remarks>
		/// <param name="p">Point to check</param>
		/// <param name="p1">First point on circle</param>
		/// <param name="p2">Second point on circle</param>
		/// <param name="p3">Third point on circle</param>
		/// <returns>true if p is inside circle</returns>
		private static bool InCircle(Geometry.Point p, Geometry.Point p1, Geometry.Point p2, Geometry.Point p3)
		{
			//Return TRUE if the point (xp,yp) lies inside the circumcircle
			//made up by points (x1,y1) (x2,y2) (x3,y3)
			//NOTE: A point on the edge is inside the circumcircle

			if (System.Math.Abs(p1.Y - p2.Y) < double.Epsilon && System.Math.Abs(p2.Y - p3.Y) < double.Epsilon)
			{
				//INCIRCUM - F - Points are coincident !!
				return false;
			}

			double m1, m2;
			double mx1, mx2;
			double my1, my2;
			double xc, yc;
						
			if (System.Math.Abs(p2.Y - p1.Y) < double.Epsilon)
			{
				m2 = -(p3.X - p2.X) / (p3.Y - p2.Y);
				mx2 = (p2.X + p3.X) * 0.5;
				my2 = (p2.Y + p3.Y) * 0.5;
				//Calculate CircumCircle center (xc,yc)
				xc = (p2.X + p1.X) * 0.5;
				yc = m2 * (xc - mx2) + my2;
			}
			else if (System.Math.Abs(p3.Y - p2.Y) < double.Epsilon)
			{
				m1 = -(p2.X - p1.X) / (p2.Y - p1.Y);
				mx1 = (p1.X + p2.X) * 0.5;
				my1 = (p1.Y + p2.Y) * 0.5;
				//Calculate CircumCircle center (xc,yc)
				xc = (p3.X + p2.X) * 0.5;
				yc = m1 * (xc - mx1) + my1;
			}
			else
			{
				m1 = -(p2.X - p1.X) / (p2.Y - p1.Y);
				m2 = -(p3.X - p2.X) / (p3.Y - p2.Y);
				mx1 = (p1.X + p2.X) * 0.5;
				mx2 = (p2.X + p3.X) * 0.5;
				my1 = (p1.Y + p2.Y) * 0.5;
				my2 = (p2.Y + p3.Y) * 0.5;
				//Calculate CircumCircle center (xc,yc)
				xc = (m1 * mx1 - m2 * mx2 + my2 - my1) / (m1 - m2);
				yc = m1 * (xc - mx1) + my1;
			}

			double dx = p2.X - xc;
			double dy = p2.Y - yc;
			double rsqr = dx * dx + dy * dy;
			//double r = Math.Sqrt(rsqr); //Circumcircle radius
			dx = p.X - xc;
			dy = p.Y - yc;
			double drsqr = dx * dx + dy * dy;

			return (drsqr <= rsqr);
		}
	}
}
