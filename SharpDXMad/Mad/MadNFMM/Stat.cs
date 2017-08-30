package nfm.open;

/**
 * Created by Rafael on 24/07/2016.
 *
 * TODO integrate fully (currently only Mad)
 */
public class Stat {
    final int[] swits;
    final float[] acelf;
    final int handb;
    final float airs;
    final int airc;
    final int turn;
    final float grip;
    final float bounce;
    final float simag;
    final float moment;
    final float comprad;
    final int push;
    final int revpush;
    final int lift;
    final int revlift;
    final int powerloss;
    final int flipy;
    final int msquash;
    final int clrad;
    final float dammult;
    final int maxmag;
    final float dishandle;
    final float outdam;
    final int cclass;
    final String names;
    final int enginsignature;

    boolean include = false;
    String createdby = "";
    int publish = 0;

    public Stat(int[] swits, float[] acelf, int handb, float airs, int airc, int turn, float grip, float bounce, float simag, float moment, float comprad, int push, int revpush, int lift, int revlift, int powerloss, int flipy, int msquash, int clrad, float dammult, int maxmag, float dishandle, float outdam, int cclass, String names, int enginsignature,
                boolean include, String createdby, int publish) {
        this(swits,
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
             enginsignature);

        this.include = include;
        this.createdby = createdby;
        this.publish = publish;
    }

    public Stat(int[] swits, float[] acelf, int handb, float airs, int airc, int turn, float grip, float bounce, float simag, float moment, float comprad, int push, int revpush, int lift, int revlift, int powerloss, int flipy, int msquash, int clrad, float dammult, int maxmag, float dishandle, float outdam, int cclass, String names, int enginsignature) {
        this.swits = swits.clone();
        this.acelf = acelf.clone();

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

    public Stat(Stat clone) {
        this.swits = clone.swits.clone();
        this.acelf = clone.acelf.clone();

        this.handb = clone.handb;
        this.airs = clone.airs;
        this.airc = clone.airc;
        this.turn = clone.turn;
        this.grip = clone.grip;
        this.bounce = clone.bounce;
        this.simag = clone.simag;
        this.moment = clone.moment;
        this.comprad = clone.comprad;
        this.push = clone.push;
        this.revpush = clone.revpush;
        this.lift = clone.lift;
        this.revlift = clone.revlift;
        this.powerloss = clone.powerloss;
        this.flipy = clone.flipy;
        this.msquash = clone.msquash;
        this.clrad = clone.clrad;
        this.dammult = clone.dammult;
        this.maxmag = clone.maxmag;
        this.dishandle = clone.dishandle;
        this.outdam = clone.outdam;
        this.cclass = clone.cclass;
        this.names = clone.names;
        this.enginsignature = clone.enginsignature;
    }

    public Stat(int cn) {
        this.swits = CarDefine.swits[cn].clone();
        this.acelf = CarDefine.acelf[cn].clone();

        this.handb = CarDefine.handb[cn];
        this.airs = CarDefine.airs[cn];
        this.airc = CarDefine.airc[cn];
        this.turn = CarDefine.turn[cn];
        this.grip = CarDefine.grip[cn];
        this.bounce = CarDefine.bounce[cn];
        this.simag = CarDefine.simag[cn];
        this.moment = CarDefine.moment[cn];
        this.comprad = CarDefine.comprad[cn];
        this.push = CarDefine.push[cn];
        this.revpush = CarDefine.revpush[cn];
        this.lift = CarDefine.lift[cn];
        this.revlift = CarDefine.revlift[cn];
        this.powerloss = CarDefine.powerloss[cn];
        this.flipy = CarDefine.flipy[cn];
        this.msquash = CarDefine.msquash[cn];
        this.clrad = CarDefine.clrad[cn];
        this.dammult = CarDefine.dammult[cn];
        this.maxmag = CarDefine.maxmag[cn];
        this.dishandle = CarDefine.dishandle[cn];
        this.outdam = CarDefine.outdam[cn];
        this.cclass = CarDefine.cclass[cn];
        this.names = CarDefine.names[cn];
        this.enginsignature = CarDefine.enginsignature[cn];

        if (cn >= CarDefine.SIXTEEN) {
            include = CarDefine.include[cn];
            createdby = CarDefine.createdby[cn];
            publish = CarDefine.publish[cn];
        }
    }
}
