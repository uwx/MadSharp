namespace Cum
{
    public class Stat
    {
        internal readonly int[] swits;
        internal readonly float[] acelf;
        internal readonly int handb;
        internal readonly float airs;
        internal readonly int airc;
        internal readonly int turn;
        internal readonly float grip;
        internal readonly float bounce;
        internal readonly float simag;
        internal readonly float moment;
        internal readonly float comprad;
        internal readonly int push;
        internal readonly int revpush;
        internal readonly int lift;
        internal readonly int revlift;
        internal readonly int powerloss;
        internal readonly int flipy;
        internal readonly int msquash;
        internal readonly int clrad;
        internal readonly float dammult;
        internal readonly int maxmag;
        internal readonly float dishandle;
        internal readonly float outdam;
        internal readonly int cclass;
        internal readonly string names;
        internal readonly int enginsignature;

        internal readonly bool include = false;
        internal readonly string createdby = "";
        internal readonly int publish = 0;

        public Stat(int[] swits, float[] acelf, int handb, float airs, int airc, int turn, float grip, float bounce,
            float simag, float moment, float comprad, int push, int revpush, int lift, int revlift, int powerloss,
            int flipy, int msquash, int clrad, float dammult, int maxmag, float dishandle, float outdam, int cclass,
            string names, int enginsignature,
            bool include, string createdby, int publish) : this(swits,
            acelf,
            handb,
            airs,
            airc,
            turn,
            grip,
            bounce,
            simag,
            moment,
            comprad,
            push,
            revpush,
            lift,
            revlift,
            powerloss,
            flipy,
            msquash,
            clrad,
            dammult,
            maxmag,
            dishandle,
            outdam,
            cclass,
            names,
            enginsignature)
        {
            this.include = include;
            this.createdby = createdby;
            this.publish = publish;
        }

        public Stat(int[] swits, float[] acelf, int handb, float airs, int airc, int turn, float grip, float bounce,
            float simag, float moment, float comprad, int push, int revpush, int lift, int revlift, int powerloss,
            int flipy, int msquash, int clrad, float dammult, int maxmag, float dishandle, float outdam, int cclass,
            string names, int enginsignature)
        {
            this.swits = swits.CloneArray();
            this.acelf = acelf.CloneArray();

            this.handb = handb;
            this.airs = airs;
            this.airc = airc;
            this.turn = turn;
            this.grip = grip;
            this.bounce = bounce;
            this.simag = simag;
            this.moment = moment;
            this.comprad = comprad;
            this.push = push;
            this.revpush = revpush;
            this.lift = lift;
            this.revlift = revlift;
            this.powerloss = powerloss;
            this.flipy = flipy;
            this.msquash = msquash;
            this.clrad = clrad;
            this.dammult = dammult;
            this.maxmag = maxmag;
            this.dishandle = dishandle;
            this.outdam = outdam;
            this.cclass = cclass;
            this.names = names;
            this.enginsignature = enginsignature;
        }

        public Stat(Stat clone)
        {
            swits = clone.swits.CloneArray();
            acelf = clone.acelf.CloneArray();

            handb = clone.handb;
            airs = clone.airs;
            airc = clone.airc;
            turn = clone.turn;
            grip = clone.grip;
            bounce = clone.bounce;
            simag = clone.simag;
            moment = clone.moment;
            comprad = clone.comprad;
            push = clone.push;
            revpush = clone.revpush;
            lift = clone.lift;
            revlift = clone.revlift;
            powerloss = clone.powerloss;
            flipy = clone.flipy;
            msquash = clone.msquash;
            clrad = clone.clrad;
            dammult = clone.dammult;
            maxmag = clone.maxmag;
            dishandle = clone.dishandle;
            outdam = clone.outdam;
            cclass = clone.cclass;
            names = clone.names;
            enginsignature = clone.enginsignature;
        }

        public Stat(int cn)
        {
            swits = CarDefine.swits.Slice(cn);
            acelf = CarDefine.acelf.Slice(cn);

            handb = CarDefine.handb[cn];
            airs = CarDefine.airs[cn];
            airc = CarDefine.airc[cn];
            turn = CarDefine.turn[cn];
            grip = CarDefine.grip[cn];
            bounce = CarDefine.bounce[cn];
            simag = CarDefine.simag[cn];
            moment = CarDefine.moment[cn];
            comprad = CarDefine.comprad[cn];
            push = CarDefine.push[cn];
            revpush = CarDefine.revpush[cn];
            lift = CarDefine.lift[cn];
            revlift = CarDefine.revlift[cn];
            powerloss = CarDefine.powerloss[cn];
            flipy = CarDefine.flipy[cn];
            msquash = CarDefine.msquash[cn];
            clrad = CarDefine.clrad[cn];
            dammult = CarDefine.dammult[cn];
            maxmag = CarDefine.maxmag[cn];
            dishandle = CarDefine.dishandle[cn];
            outdam = CarDefine.outdam[cn];
            cclass = CarDefine.cclass[cn];
            names = CarDefine.names[cn];
            enginsignature = CarDefine.enginsignature[cn];

            if (cn >= CarDefine.SIXTEEN)
            {
                include = CarDefine.include[cn];
                createdby = CarDefine.createdby[cn];
                publish = CarDefine.publish[cn];
            }
        }
    }
}