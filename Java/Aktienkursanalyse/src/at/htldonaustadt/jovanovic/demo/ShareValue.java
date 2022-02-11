package at.htldonaustadt.jovanovic.demo;
import lombok.*;

import java.time.LocalDate;

@AllArgsConstructor
@Getter
@ToString
public class ShareValue {
    // timestamp,open,high,low,close,volume
    private LocalDate timestamp; // Date
    private float openPrice;
    private float high;
    private float low;
    private float closePrice;
    private float volume;
}
