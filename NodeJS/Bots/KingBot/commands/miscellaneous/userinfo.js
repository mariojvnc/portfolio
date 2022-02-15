const { MessageEmbed } = require("discord.js")
const colors = require("../../colors.json");

module.exports = {
    config: {
        name: "userinfo",
        description: "Zeigt dir deine Info!",
        usage: "!userinfo",
        category: "miscellaneous",
        accessableby: "Members",
        aliases: ["si", "serverdesc"]
    },
    run: async (bot, message, args) => {
    let sEmbed = new MessageEmbed()
        .setColor(colors.gold)
        .setTitle("Benutzer Information von " + message.author.username)
        .setThumbnail(message.author.displayAvatarURL())
        .setAuthor(`${message.author.username}`, message.author.displayAvatarURL())
        .addField("**Username:**", `${message.author.username}`, true)
        .addField("**ID:**", `${message.author.id}`, true)
        .addField("**Diskriminator:**", `${message.author.discriminator}`, true)
        .setTimestamp()
        .setFooter(`KingBot | `, bot.user.displayAvatarURL())
    message.channel.send(sEmbed);
    }
}