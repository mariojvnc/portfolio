module.exports = async bot => {
    console.log(`${bot.user.username} is online`)
   // bot.user.setActivity("Hello", {type: "STREAMING", url:"https://twitch.tv/Strandable"});

   let statuses = [
       'Mario = King Nr. 1',
       `${bot.user.username} = Nr. 1`,
       "!help",
       `über ${bot.guilds.cache.size} Leute!`
   ]

   setInterval(function() {
       let status = statuses[Math.floor(Math.random() * statuses.length)];
       bot.user.setActivity(status, { type: "WATCHING" });

   }, 16000)

}