const Discord = require('discord.js');
const color = require('../../colors.json');

module.exports = {
    config: {
        name: "sag",
        description: "sends a message that was inputted to a channel",
        usage: "!sag",
        category: "moderation",
        accessableby: "Staff",
        aliases: ["acc", "announcement"]
    },
    run: async (bot, message, args) => {

        if (!message.member.roles.cache.find(r => r.name === "King of Kingz") /*&& !message.member.roles.cache.find(r => r.name === "Ava`s Freund 💑")*/) {
            let errorEmbed = new Discord.MessageEmbed()
                .setColor(color.red_light)
                .setAuthor(`${message.guild.name}`, message.author.displayAvatarURL())
                .setTitle(`${message.author.username} hat **versucht**, im Channel "${message.channel.name}" den Befehl *!sag* auszuführen`)
                .setThumbnail(message.author.displayAvatarURL())
                .setTimestamp()
                .setFooter(`Kingbot `, bot.user.displayAvatarURL())

            let sChannel = message.guild.channels.cache.find(c => c.name === "🕖-modlogs");
            sChannel.send(errorEmbed);
            return message.reply("du kannst diesen Befehl leider nicht ausführen! ⛔");
        }

        let argsresult;
        let mChannel = message.mentions.channels.first()

        let x = args.slice(1).join(" ");

        if (args[0] == "embed") {
            message.delete();
            let embed = new Discord.MessageEmbed()
                .setColor(color.gold)
                .setAuthor(`${message.author.username}`, message.author.displayAvatarURL())
                .setTitle(`${x}`)
                .setTimestamp()
                .setFooter(`KingBot`)
            message.channel.send(embed)


            let modEmbed = new Discord.MessageEmbed()
                .setColor(color.green_light)
                .setAuthor(`${message.guild.name}`, message.author.displayAvatarURL())
                .setTitle(`${message.author.username} hat im Channel "${message.channel.name}" den Befehl *!sag embed* ausgeführt`)
                .setThumbnail(message.author.displayAvatarURL())
                .setTimestamp()
                .setFooter(`Kingbot `, bot.user.displayAvatarURL())

            let sChannel = message.guild.channels.cache.find(c => c.name === "🕖-modlogs");
            sChannel.send(modEmbed);
        } else {
            message.delete()
            if (mChannel) {
                argsresult = args.slice(1).join(" ")
                mChannel.send(argsresult)
            } else {
                argsresult = args.join(" ")
                message.channel.send(argsresult)
            }
            let modEmbed2 = new Discord.MessageEmbed()
                .setColor(color.green_light)
                .setAuthor(`${message.guild.name}`, message.author.displayAvatarURL())
                .setTitle(`${message.author.username} hat im Channel "${message.channel.name}" den Befehl *!sag* ausgeführt`)
                .setThumbnail(message.author.displayAvatarURL())
                .setTimestamp()
                .setFooter(`Kingbot `, bot.user.displayAvatarURL())
            let sChannel = message.guild.channels.cache.find(c => c.name === "🕖-modlogs");
            sChannel.send(modEmbed2);

        }
    }


}