const { MessageEmbed } = require("discord.js")
const color = require("../../colors.json");

module.exports = {
    config: {
        name: "clear",
        description: "Chat clearen :)",
        usage: "!clear",
        category: "miscellaneous",
        accessableby: "Members",
        aliases: ["si", "serverdesc"]
    },
    run: async (bot, message, args) => {

            if (!message.member.roles.cache.find(r => r.name === "King of Kingz") && !message.member.roles.cache.find(r => r.name === "Kingz") && !message.member.roles.cache.find(r => r.name === "Queen")) {
                let errorEmbed = new MessageEmbed()
                .setColor(color.red_light)
                .setAuthor(`${message.guild.name}`, message.author.displayAvatarURL())
                .setTitle(`${message.author.username} hat **versucht**, im Channel "${message.channel.name}" den Befehl *!clear* auszuführen`)
                .setThumbnail(message.author.displayAvatarURL())
                .setTimestamp()
                .setFooter(`Kingbot `, bot.user.displayAvatarURL())

            let sChannel = message.guild.channels.cache.find(c => c.name === "🕖-modlogs");
            sChannel.send(errorEmbed);
            return message.reply("du kannst diesen Befehl leider nicht ausführen!");
            } 
    
                /*code*/
    
                if (args[0] == null) {
                    return message.reply('gebe bitte eine Anzahl an')
                }
                var numbers = /^[0-9]+$/;
                if (args[0].match(numbers)) {
                    var anz = new String(args[0].toString());
                    message.channel.bulkDelete(args[0]);
                    message.channel.send('*' + anz + ' Nachrichten wurden von ' + message.author.username + ' entfernt*');
                }
                else {
                    return message.reply('Gebe bitte eine Anzahl an');
                }
                message.delete();


                let modEmbed = new MessageEmbed()
            .setColor(color.green_light)
            .setAuthor(`${message.guild.name}`, message.author.displayAvatarURL())
            .setTitle(`${message.author.username} hat im Channel "${message.channel.name}" den Befehl *!clear* ausgeführt`)
            .setThumbnail(message.author.displayAvatarURL())
            .setTimestamp()
            .setFooter(`Kingbot `, bot.user.displayAvatarURL())

        let sChannel = message.guild.channels.cache.find(c => c.name === "🕖-modlogs");
        sChannel.send(modEmbed);
    
        }
    
    }
