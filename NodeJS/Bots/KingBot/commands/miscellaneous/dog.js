const { MessageEmbed } = require("discord.js")
const color = require("../../colors.json");
const fetch = require('node-fetch');


module.exports = { 
    config: {
        name: "dog",
        description: "schickt einen Hund in den Chat!",
        usage: "!dog",
        category: "miscellaneous",
        accessableby: "Members",
        aliases: ["doggo", "puppy"]
    },
    run: async (bot, message, args) => {
    let msg = await message.channel.send("Generiere...")

    fetch(`https://dog.ceo/api/breeds/image/random`)
    .then(res => res.json()).then(body => {
        if(!body) return message.reply("ich bin kaputt gegangen 💔")
        let embed = new MessageEmbed()
            .setColor(color.cream)
            .setAuthor(message.author.username, message.guild.iconURL())
            .setImage(body.message)
            .setTimestamp()
            .setFooter(`${bot.user.username} | von ${message.author.username} angefordert`, bot.user.avatarURL())
        message.channel.send(embed);
        msg.delete();
        message.delete();
        })
    }
}