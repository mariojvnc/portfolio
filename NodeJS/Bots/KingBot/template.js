const { MessageEmbed } = require("discord.js")
const colors = require("../../colors.json");

module.exports = {
    config: {
        name: "commanName",
        description: "Info",
        usage: "!command",
        category: "ordner",
        accessableby: "Members",
        aliases: ["si", "serverdesc"]
    },
    run: async (bot, message, args) => {
        //code
    }
}