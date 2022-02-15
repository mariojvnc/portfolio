const { prefix } = require("../../botconfig.json");

module.exports = async (bot, message) => { 
    console.log(`${message.author.username}: ${message.content}`)

    if(message.author.bot || message.channel.type === "dm") return;
    if (message.content === "hey" || message.content === "Hey" || message.content === "hi" || message.content === "Hi" || message.content === "hallo" || message.content === "Hallo" || message.content === "servus" || message.content === "Servus") {
        message.reply('hey was geht ' + `:call_me: `);
    }
    let args = message.content.slice(prefix.length).trim().split(/ +/g);
    let cmd = args.shift().toLowerCase();

    if(!message.content.startsWith(prefix)) return;
    let commandfile = bot.commands.get(cmd) || bot.commands.get(bot.aliases.get(cmd));
    if(commandfile) commandfile.run(bot, message, args);
}