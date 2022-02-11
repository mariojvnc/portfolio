package at.htldonaustadt.jovanovic.demo;

import java.io.File;
import java.time.LocalDate;
import java.time.LocalTime;
import java.util.LinkedList;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

public class AirTrafficControl extends LinkedList<Flight> {
    private LocalDate today;
    private Random rnd;

    // 3.
    private List<StormEvents> observers;

    public void subscribe(StormEvents s) {
        if ( s != null )
            observers.add(s);
    }

    public void unsubscribe(StormEvents s) {
        observers.remove(s);
    }

    public AirTrafficControl(){}

    public void load (String path) {
        Scanner scanner = new Scanner(new File(path));
        scanner.nextLine();
        while (!scanner.hasNextLine())
        {
            String line = scanner.nextLine();
            String seperator = ",";
            String[] parts = line.split(seperator);

            String[] parts_time = parts[0].split(":");
            int hour = Integer.parseInt(parts_time[0]);
            int minutes = Integer.parseInt(parts_time[1]);

            LocalTime startTime = LocalTime.of(hour, minutes, 0);

            this.add(new Flight(startTime, Integer.parseInt(parts[1]), parts[2], parts[3], Double.parseDouble(parts[4]),
                    Double.parseDouble(parts[5]), Double.parseDouble(parts[6]), Double.parseDouble(parts[7]), Double.parseDouble(parts[4]), Double.parseDouble(parts[5])));

            // this = this.sort();
        }
        scanner.close();
    }
    public void simulate() throws InterruptedException {
        LocalTime startTime =  LocalTime.of(7, 30, 0);
        LocalTime endTime =  LocalTime.of(13, 00, 0);

        for (LocalTime time = startTime; time.isBefore(endTime); time = time.plusMinutes(15))
        {
            System.out.println("\n" + time + "Uhr");

            for (var flight : this)
            {
                Thread t1 = new Thread(flight);
                // Thread
                if (time == flight.getStartTime())
                {
                    t1.start();
                    this.subscribe(flight);
                    // flugzeug.Notlandung += NeueNotlandung;
                }
            }

            // 2. Triggern
            // zu 30 % Unwetter
            if (rnd.nextInt(100) < 30)
            {
                int x_coordinate = rnd.nextInt((10) + 1);
                int y_coordinate = rnd.nextInt((10) + 1);
                //TypeOfStorm unwetterart = rnd.nextInt(TypeOfStorm.values().length);
                TypeOfStorm storm = TypeOfStorm.Gewitter;

                for(StormEvents s : observers){
                    s.newStorm( this, storm, x_coordinate, y_coordinate);
                }

                //Console.WriteLine($"\n-------------------------------------------\nUNWETTERWARNUNG auf {x_koordinate}/{y_koordinate} | Art: {unwetterart}\n-------------------------------------------\n");
            }

            Thread.sleep(1000);
        }
    }

}
