package at.htldonaustadt.jovanovic.demo;
import java.util.*;

public class HSL {
    private int h;
    private int s;
    private int l;

    public HSL(int h, int s, int l) {
        this.h = h;
        this.s = s;
        this.l = l;
    }

    public int getH() {
        return Math.round(h);
    }

    public int getS() {
        return Math.round(s);
    }

    public void setH(int h) {
        this.h = h;
    }

    public void setS(int s) {
        this.s = s;
    }

    public void setL(int l) {
        this.l = l;
    }

    public int getL() {
        return Math.round(l);
    }

}
