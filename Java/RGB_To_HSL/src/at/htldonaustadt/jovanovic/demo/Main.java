package at.htldonaustadt.jovanovic.demo;
import java.util.*;

public class Main {

    private static HSL convertRGBtoHSL(int r, int g, int b){

        // R´, G´, B´
        float r_ = (float)r/255;
        float g_ = (float)g/255;
        float b_ = (float)b/255;

        // MAX, MIN, DIFF
        float  max = Math.max(Math.max(r_, b_), g_);
        float  min = Math.min(Math.min(r_, b_), g_);
        float  diff = max - min;

        // H
        float h = 0;
        if(diff == 0){
            h = 0;
        } else if (max == r_) {
            h = 60 * ( (g_ - b_)/ diff );

        } else if (max == g_) {
            h = 60 * ( (b_ - r_)/ diff + 2 );
        } else {
            // max has to be b_
            h = 60 * ( (r_ - g_)/ diff + 4 );
        }

        if(h < 0)
            h += 360;

        // L
        float l = (max + min) / 2;

        // S
        float s = 0;
        if(diff != 0){
            s = diff / (1 - Math.abs(2 * l - 1) );
        }

        s*= 100;
        l*= 100;
        return new HSL((int)h, (int)s, (int)l);
    }
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("R: ");
        int r = scanner.nextInt();
        System.out.print("G: ");
        int g = scanner.nextInt();
        System.out.print("B: ");
        int b = scanner.nextInt();

        HSL hsl = convertRGBtoHSL(r, g, b);
        System.out.println("\nH: " + hsl.getH());
        System.out.println("S: " + hsl.getS() + "%");
        System.out.println("L: " + hsl.getL() + "%");
    }
}
