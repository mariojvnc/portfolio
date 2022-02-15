const { readdirSync } = require("fs")
const { MessageEmbed } = require("discord.js")

module.exports = (bot) => {
    bot.on('guildMemberAdd', member => {
        const channel = member.guild.channels.cache.find(channel => channel.name === "👋-willkommen");
        let mainrole = member.guild.roles.cache.find(role => role.name === "Frischling");
        
        member.roles.add(mainrole);
    
        if (!channel) return;
        channel.send(`Willkommen auf DamnBro, ${member}. Fühle dich geehrt!`)
        const embed = new MessageEmbed()
            .setColor(0x2AFCB8)
            .setTitle('Server Information')
            .setAuthor(`${member.guild}`, bot.user.displayAvatarURL())
            .attachFiles(['./assets/willkommen.png'])
            .addField('**Server Name**', member.guild.name, true)
            .addField('**Server Owner**', member.guild.owner, true)
            .addField(`**Leute auf ${member.guild.name}**`, member.guild.memberCount, true)
            .addField('**Der höchste Rang**', member.guild.roles.highest, true)
            .addField('**Region**', member.guild.region, true)
            .addField('**Afk**', member.guild.afkChannel, true)
            .addField('**Joined**', member.guild.joinedAt, true)
            .setThumbnail(member.guild.iconURL())
            .setTimestamp()
            .setFooter(`KingBot `, bot.user.displayAvatarURL())
    
        channel.send(embed);
    });
    const load = dirs => {
        const events = readdirSync(`./events/${dirs}/`).filter(d => d.endsWith('.js'))
        for (let file of events) {
            const evt = require(`../events/${dirs}/${file}`)
            let eName = file.split(".")[0]
            
            bot.on(eName, evt.bind(null, bot))

            
        }
        

    }
    ["client", "guild"].forEach(x => load(x))
}

