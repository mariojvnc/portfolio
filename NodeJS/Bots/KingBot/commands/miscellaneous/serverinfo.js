const { MessageEmbed } = require("discord.js")
const colors = require("../../colors.json");

module.exports = {
    config: {
        name: "serverinfo",
        description: "Zeigt dir die Info von dem Server!",
        usage: "!serverinfo",
        category: "miscellaneous",
        accessableby: "Members",
        aliases: ["si", "serverdesc"]
    },
    run: async (bot, message, args) => {
    let sEmbed = new MessageEmbed()
        .setColor(colors.gold)
        .setTitle("Server Info")
        .setThumbnail(message.guild.iconURL)
        .setAuthor(`${message.guild.name}`, message.guild.iconURL())
        .addField("**Server Name:**", `${message.guild.name}`, true)
        .addField("**Owner:**", `${message.guild.owner}`, true)
        .addField("**Leute:**", `${message.guild.memberCount}`, true)
        .addField("**Höchster Rang:**", message.guild.roles.highest, true)
        .setThumbnail(message.guild.iconURL())
        .setTimestamp()
        .setFooter(`KingBot | `, bot.user.displayAvatarURL());
    message.channel.send(sEmbed);
    }
}