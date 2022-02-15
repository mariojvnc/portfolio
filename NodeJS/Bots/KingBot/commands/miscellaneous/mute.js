const Discord = require('discord.js');
const color = require('../../colors.json');
const ms = require('ms');

module.exports = {
    config: {
        name: "mute",
        description: "Mute einen member im Discord!",
        usage: "!mute",
        category: "miscellaneous",
        accessableby: "Members",
        aliases: ["m", "nospeak"]
    },
    run: async (bot, message, args) => {
        if (!message.member.hasPermission("MANAGE_ROLES") || !message.guild.owner) return message.reply(`:no_entry: `)

        if (!message.guild.me.hasPermission(["MANAGE_ROLES", "ADMINISTRATOR"])) return message.channel.send('Ich darf diesen Befehl nicht ausführen ;(')
        if (!args[0]) {
            const embed = new Discord.MessageEmbed()
                .setColor(color.red_dark)
                .setAuthor(`KingBot`, bot.user.displayAvatarURL())
                .setDescription(`Wen und wie lange soll ich muten?`)
                .setTimestamp()
                .setFooter(`Kingbot `)
            return message.channel.send(embed);
        }

        let reason = "**Keinen Grund angegeben**"
        if (args[2]) {
            let x = args.slice(2).join(" ");
            reason = `**${x}**`;
        }

        let person = message.guild.member(message.mentions.members.first() || message.guild.members.fetch(args[0]));
        if (!person) {
            const embed = new Discord.MessageEmbed()
                .setColor(color.red_dark)
                .setDescription(`Ich konnte "${args[0]}" leider nicht finden`)
                .setTimestamp()
                .setFooter(`KingBot`, bot.user.displayAvatarURL())
            return message.channel.send(embed);
        }

        let mainrole = "";

        if(message.mentions.members.first().roles != "King of Kingz" && message.mentions.members.first().roles != "Frischling" && message.mentions.members.first().roles != "Botz" && message.mentions.members.first().roles != "Kingz"){
            /*rolle Queen*/ 
             mainrole = message.guild.roles.cache.find(r => r.name === "Queen");
        }
       if(message.mentions.members.first().roles != "King of Kingz" && message.mentions.members.first().roles != "Frischling" && message.mentions.members.first().roles != "Botz" && message.mentions.members.first().roles != "Queen"){
            /*rolle Kingz*/ 
             mainrole = message.guild.roles.cache.find(r => r.name === "Kingz");
        }
        if(message.mentions.members.first().roles != "King of Kingz" && message.mentions.members.first().roles != "Queen" && message.mentions.members.first().roles != "Botz" && message.mentions.members.first().roles != "Queen"){
            /*rolle Frischling*/ 
             mainrole = message.guild.roles.cache.find(r => r.name === "Frischling");
        }
        let muterole = message.guild.roles.cache.find(r => r.name === "muted 🔇");

        if (!muterole) {
            const embed = new Discord.MessageEmbed()
                .setColor(color.red_dark)
                .setDescription(`Ich konnte die Mute-Rolle nicht finden`)
                .setTimestamp()
                .setFooter(`Kingbot `, bot.user.displayAvatarURL())
            return message.channel.send(embed);
        }

        let time = args[1];
        if (!time) {
            const embed = new Discord.MessageEmbed()
                .setColor(color.red_dark)
                .setDescription(`Wie lange soll ich ${person.user.username} 🔇?`)
                .setTimestamp()
                .setFooter(`Kingbot `, bot.user.displayAvatarURL())
            return message.channel.send(embed);
        }

        message.delete();

        person.roles.remove(mainrole.id);
        person.roles.add(muterole.id);



        let embed = new Discord.MessageEmbed()
            .setColor(color.red_dark)
            .setAuthor(`${message.guild.name}`, message.author.displayAvatarURL())
            .setTitle(`${person.user.username} wurde gemuted 🔇 !`)
            .setThumbnail(person.user.displayAvatarURL())
            .addField("**Moderation:**", "mute", true)
            .addField("**Gemuted von:**", message.author.username, true)
            .addField("**Grund:**", reason, true)
            .addField("**Zeit:**", time, true)
            /* .addField("**Datum**", message.createdAt, true)*/
            .setTimestamp()
            .setFooter(`Kingbot `, bot.user.displayAvatarURL())

        let sChannel = message.guild.channels.cache.find(c => c.name === "🕖-modlogs");
        sChannel.send(embed);


        setTimeout(function () {
            person.roles.remove(muterole.id);
            person.roles.add(mainrole.id);
            let embed = new Discord.MessageEmbed()
                .setColor(color.green_light)
                .setAuthor(`${message.guild.name}`, message.author.displayAvatarURL())
                .setThumbnail(person.user.displayAvatarURL())
                .setTitle(`${person.user.username} wurde entmuted!` + `:loud_sound: `)
                .addField("**Moderation:**", "mute", true)
                .addField("**Gemuted gewesen von:**", message.author.username, true)
                .addField("**Grund:**", reason, true)
                .addField("**Zeit:**", time, true)
                /*.addField("**Datum**", message.createdAt, true)*/
                .setTimestamp()
                .setFooter(`Kingbot `, bot.user.displayAvatarURL())
            let sChannel = message.guild.channels.cache.find(c => c.name === "🕖-modlogs");
            sChannel.send(embed);
        }, ms(time));


    }
}

/*module.exports.run = async (bot, message, args) => {
    if(!message.member.hasPermission("MANAGE_ROLES")||!message.guild.owner) return message.reply(`:no_entry: `)

if(!message.guild.me.hasPermission(["MANAGE_ROLES", "ADMINISTRATOR"])) return message.channel.send('Ich darf diesen Befehl nicht ausführen ;(')

    let mutee = nessage.mentions.members.first() ||message.guild.members.get(args[0]);
    if(!mutee) return message.reply('wen soll ich muten? ' + `:mute: `);

    let reason = args.slice(1).join(" ");
    if(!reason) reason = "*keinen Grund angegeben*"

    let muterole = message.member.roles.cache.find(r => r.name === "muted")
    if(!muterole){
        try{
            muterole = await message.guild.createRole({
                name: "muted",
                color: "#514f48",
                premissions: []
            })
            message.guild.channels.forEach(async (channel, id)=> {
                await channel.overwritePermissions(muterole, {
                    SEND_MESSAGES: false,
                    ADD_REACTIONS: false,
                    SEND_TTS_MESSAGES: false,
                    ATTACH_FILES: false,
                    SPEAK: false
                })
            })
        } catch (e){
            console.log(e.stack);
        }
    }
    mutee.add(muterole.id).then(() => {
        message.delete();
        mutee.send(`Hey, du wurdest wegen "${reason}" in ${message.guild.name} gemuted!`)
        message.channel.send(`${mutee.user.username} wurde erfolgreich gemuted.`)
    })

    let embed = Discord.MessageEmbed()
    .setColor(color.red_dark)
    .setAuthor(`${message.guild.name}`, message.guild.iconURL())
    .addField("**Moderation:**", "mute")
    .addField("**Moderator:**", message.author.username)
    .addField("**Grund:**", reason)
    .addField("**Datum**", message.createtAt.toLocaleString())

    let sChannel = message.guild.channels.find(c => c.name ==="🕖-modlogs");
    sChannel.send(emebd);





}
module.exports = {
    config: {
        name: "mute",
        description: "Mute einen member im Discord!",
        usage: "!mute",
        category: "miscellaneous",
        accessableby: "Members",
        aliases: ["m", "nospeak"]
    }
}*/