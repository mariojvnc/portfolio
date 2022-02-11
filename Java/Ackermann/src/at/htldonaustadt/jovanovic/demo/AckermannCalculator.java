package at.htldonaustadt.jovanovic.demo;

import java.math.BigInteger;

public class AckermannCalculator {
    public static BigInteger ackermann(BigInteger m, BigInteger n) {
        if (m.equals(BigInteger.ZERO))
            return n.add(BigInteger.ONE);
        else if (n.equals(BigInteger.ZERO))
            return ackermann(m.subtract(BigInteger.ONE), BigInteger.ONE);
        else  return ackermann(m.subtract(BigInteger.ONE), ackermann(m, n.subtract(BigInteger.ONE)));
    }
}