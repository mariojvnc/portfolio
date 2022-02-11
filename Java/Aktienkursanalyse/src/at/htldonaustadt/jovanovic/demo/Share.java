package at.htldonaustadt.jovanovic.demo;

import java.text.DecimalFormat;
import java.time.*;
import java.util.*;
import lombok.*;

enum TimeInterval { wöchentlich, monatlich }


@Getter
@AllArgsConstructor
public class Share extends ArrayList<ShareValue> {
    public List<Double> CalcAverages(LocalDate from, LocalDate to, TimeInterval interval)
    {
        List<Double> averages = new ArrayList<>();

        return  averages;
    }
    public List<Double> CalcStdDeviations(LocalDate from, LocalDate to, TimeInterval interval)
    {
        List<Double> devations = new ArrayList<>();

        return  devations;
    }
    public double CalcIncrease(LocalDate dt, int numberOfDatapoints)
    {
        double increase = 0;

        return  increase;
    }

    @Override
    public String toString() {
        StringBuilder builder = new StringBuilder();
        // timestamp,open,high,low,close,volume
        for(ShareValue shareValue : this){
            builder.append(shareValue.getTimestamp()).append("|").append(shareValue.getOpenPrice()).append("|").append(shareValue.getHigh())
                    .append("|").append(shareValue.getLow()).append("|").append(shareValue.getVolume()).append("\n");
        }
        return builder.toString();
    }
}
