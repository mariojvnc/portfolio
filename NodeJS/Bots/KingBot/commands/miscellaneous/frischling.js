const Discord = require('discord.js');
const color = require('../../colors.json');

module.exports = {
    config: {
        name: "ava",
        description: "love",
        usage: "!ava",
        category: "miscellaneous",
        accessableby: "Members",
        aliases: ["m", "nospeak"]
    },
    run: async (bot, message, args) => {
        if (message.author.username == "brezo072") {
            let errorEmbed = new Discord.MessageEmbed()
                .setColor(color.red_light)
                .setAuthor(`${message.guild.name}`, message.author.displayAvatarURL())
                .setTitle(`${message.author.username} hat **versucht**, im Channel "${message.channel.name}" den Befehl *!sag* auszuführen`)
                .setThumbnail(message.author.displayAvatarURL())
                .setTimestamp()
                .setFooter(`Kingbot `, bot.user.displayAvatarURL())

            let sChannel = message.guild.channels.cache.find(c => c.name === "🕖-modlogs");
            sChannel.send(errorEmbed);
            return message.reply(`amk brezo versuch´s nicht mal du bist nur neidisch 😐 ...\n**Bald wird´s bro**`)
        }

        if (message.member.roles.cache.find(r => r.name === "King of Kingz") && message.member.roles.cache.find(r => r.name === "Ava`s Freund 💑")){
            let errorEmbed2 = new Discord.MessageEmbed()
            .setColor(color.red_light)
            .setAuthor(`${message.guild.name}`, message.author.displayAvatarURL())
            .setTitle(`${message.author.username} hat **versucht**, im Channel "${message.channel.name}" den Befehl *!sag* auszuführen`)
            .setThumbnail(message.author.displayAvatarURL())
            .setTimestamp()
            .setFooter(`Kingbot `, bot.user.displayAvatarURL())

        let sChannel = message.guild.channels.cache.find(c => c.name === "🕖-modlogs");
        sChannel.send(errorEmbed2);
        return message.reply("du kannst diesen Befehl leider nicht ausführen!");
        } 

        let embed = new Discord.MessageEmbed()
            .setColor(color.red_dark)
            .attachFiles(['./assets/avarose.jpg'])
            .setAuthor(`${message.author.username}`, message.author.displayAvatarURL())
            .setTitle(`Ava Rose ist ${message.author.username}´s Freundin 💖💞`)
            .setThumbnail(message.author.displayAvatarURL())
            .addField("**Kennengelernt am**", "01.01.2020", true)
            .addField("**Verlobt am**", "02.01.2020", true)
            .addField("**Insta Babe**", "[click me 💘](https://www.instagram.com/ava.rxsee/?hl=de)", true)
            .addField("**TikTok Baby**", "[click me 💘](https://www.instagram.com/ava.rxsee/?hl=de)", true)
            .addField("**Busines bejbe**", "ava@talentxent.com", true)
            .setDescription(`*Love is not finding someone to live with\nit's finding someone you can't live without. ...*`)
            .setTimestamp()
            .setFooter(`In ewiger Liebe 💑 `, bot.user.displayAvatarURL())

        message.channel.send(embed)


        let modEmbed = new Discord.MessageEmbed()
            .setColor(color.green_light)
            .setAuthor(`${message.guild.name}`, message.author.displayAvatarURL())
            .setTitle(`${message.author.username} hat im Channel "${message.channel.name}" den Befehl *!ava* ausgeführt`)
            .setThumbnail(message.author.displayAvatarURL())
            .setTimestamp()
            .setFooter(`Kingbot `, bot.user.displayAvatarURL())

        let sChannel = message.guild.channels.cache.find(c => c.name === "🕖-modlogs");
        sChannel.send(modEmbed);

    }
}   