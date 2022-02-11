package at.htldonaustadt.jovanovic.demo;

import java.io.File;
import java.io.FileNotFoundException;
import java.time.LocalTime;
import java.util.*;
import java.util.stream.Collectors;

public class FlightControl implements Runnable {
    private LinkedList<Flight> flights;
    private List<StormEvent>observers;

    public FlightControl(){
        flights = new LinkedList<>();
        observers = new ArrayList<>();
    }

    public void subscribe(StormEvent e){
        if(e != null)
            observers.add(e);
    }
    public void unsubscribe(StormEvent e){ observers.remove(e); }

    public void load(String path){
        try(Scanner scanner = new Scanner(new File(path))){
            scanner.nextLine();
            while(scanner.hasNextLine()){
                String [] parts = scanner.nextLine().split(",");
                Kind kind = Kind.Cargo;
                if (parts[3].equals("Passagier")){
                    kind = Kind.Passenger;
                }
                flights.add(new Flight(LocalTime.parse(parts[0]),
                        Integer.parseInt(parts[1]),
                        parts[2],
                        kind,
                        Double.parseDouble(parts[4]),
                        Double.parseDouble(parts[5]),
                        Double.parseDouble(parts[6]),
                        Double.parseDouble(parts[7])
                        ));
            }
            flights.stream()
                    .sorted(Comparator
                            .comparing(Flight :: getStart)
                            .thenComparing(Flight :: getName));

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }
    private static Random rnd = new Random();
    public void simulate(){

        for(LocalTime time = LocalTime.of(7, 30); time.isBefore(LocalTime.of(13, 0)); time = time.plusMinutes(15)){
            Flight flight = flights.peek();
            if (flight != null && flight.getStart().equals(time)) {
                // flight start
                Thread flyThread = new Thread(flight);
                subscribe(flight);
                flyThread.start();
                flights.remove(flight);
            }

            if(rnd.nextInt(100) < 30){
                double xStorm = rnd.nextInt(11);
                double yStorm = rnd.nextInt(11);

                // event trigger
                observers.forEach(o -> {
                    o.newStorm(this, xStorm, yStorm);
                });
            }

            try {
                Thread.sleep(250);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    @Override
    public void run() {
        simulate();
    }
}