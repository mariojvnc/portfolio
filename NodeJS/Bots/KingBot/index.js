const {token} = require("./botconfig.json");
const {Client, Collection} = require("discord.js");
const bot = new Client();
const cheerio = require('cheerio');
 
const request = require('request');


["commands", "aliases"].forEach(x => bot[x] = new Collection());
["console", "command", "event"].forEach(x=>require(`./handlers/${x}`)(bot));
/*
    if (cmd == "hund" || cmd == "dog") {
        let msg = await message.channel.send("Generiere ...")
        let { body } = await superagent.get('https://dog.ceo/api/breeds/image/random');

        if (!body) return message.channel.send(`Sorry bro` + ` :tired_face:` + `\n Versuch's nochmal!`);
        let embed = new Discord.MessageEmbed()
            .setColor(colors.cream)
            .setAuthor(message.author.username, message.guild.iconURL())
            .setImage(body.message)
            .setTimestamp()
            .setFooter(`${bot.user.username} | von ${message.author.username} angefordert`, bot.user.avatarURL())
        message.channel.send(embed);
        msg.delete();
        message.delete();
    }
*/


bot.on('message', message => {
    var PREFIX = "!";
    let args = message.content.substring(PREFIX.length).split(" ");
    
    switch (args[0]) {
        case 'foto':
        image(message, args);
 
        break;
    }
 
});
 
function image(message, args){
    var search = args.slice(1).join(" ");
    var options = {
        url: "http://results.dogpile.com/serp?qc=images&q=" + search,
        method: "GET",
        headers: {
            "Accept": "text/html",
            "User-Agent": "Chrome"
        }
    };

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
bot.login(token);