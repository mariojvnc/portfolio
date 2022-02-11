package at.htldonaustadt.jovanovic.demo;

public class Main {

    public static void main(String[] args) {
        User user1 = new User("Max");
        User user2 = new User("Maria");
        User user3 = new User("Filip");

        YouTubeChannel channel = new YouTubeChannel("Relaxed Coding");

        channel.subscribe(user1);
        channel.subscribe(user2);
        channel.subscribe(user3);

        channel.process();

        channel.unsubscribe(user1);


        channel.process();
    }
}