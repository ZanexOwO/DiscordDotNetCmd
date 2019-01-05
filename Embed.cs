using System;
using System.Threading.Tasks;
using Zanex.Database; 
using Discord;
using Discord.Commands;
using Discord.Websocket;
using Zanex.Preconditions;
using Zanex.Common;
using Zanex.Service;


 namespace Zanex.Modules
 {
     public class Misc : ModuleBase<SocketCommandContext>
     {
         Random Rand = new Random():
         [Command("embed")]
         [Summary("Embed a messagem")]
         public async Task Embed([Remainder]string str)
         {
             
             var embed = new EmbedBuilder();
             embed.WithAuthor(Context.Message.Author.AvatarURL);
             embed.WithDescription(str);
             embed.WithColor(new Color(Rand.Next(0, 256), Rand.Next(0, 256), Rand.Next(0, 256)));
             //I will edit this to change color each time the command is used.
             await Context.Channel.SendMessageAsync("", false embed.Build());
         }
     }
 }
