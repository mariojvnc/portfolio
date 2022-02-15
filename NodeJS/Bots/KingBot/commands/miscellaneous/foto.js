const { MessageEmbed } = require("discord.js")
const colors = require("../../colors.json");
const cheerio = require('cheerio');
const request = require


module.exports = {
    config: {
        name: "foto",
        description: "Ein zufälliges Foto! (optional: danach ein wort)",
        usage: "!foto",
        category: "miscellaneous",
        accessableby: "Members",
        aliases: ["si", "serverdesc"]
    },
    run: async (bot, message, args) => {
        //code
        image(message);

        function image(message){
            var search = args.slice(1).join(" ").toString();
        
            var options = {
                url: "http://results.dogpile.com/serp?qc=images&q=" + search,
                method: "GET",
                headers: {
                    "Accept": "text/html",
                    "User-Agent": "Chrome"
                }
            };
         
            
        }
        request(options, function(error, response, responseBody) {
            if (error) {
                return;
            }
        
        
            $ = cheerio.load(responseBody);
        
        
            var links = $(".image a.link");
        
            var urls = new Array(links.length).fill(0).map((v, i) => links.eq(i).attr("href"));
           
            console.log(urls);
        
            if (!urls.length) {
               
                return;
            }
        
            // Send result
            message.channel.send( urls[Math.floor(Math.random() * urls.length)]);
        });

    }
    
}

