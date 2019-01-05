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
    [Command("Serverinfo")] 
		[Alias("guildinfo", "sinfo", "guild")]
		[Summary("Shows current available server information")]
		[Remarks("None Required")]
		public async Task ServerInfo(string guildName = null)
		{
    //Meh Just Some Local Variables OwO
			var guild = Context.Guild;
			var roles = guild.Roles;
			var users = guild.Users;
			int usercount = users.Count(x => x.IsBot == false);
			var gusersnobot = users.Where(x => x.IsBot == false);
			var gusersbotonly = users.Where(x => x.IsBot == true);
			var config = GlobalGuildAccounts.GetGuildAccount(Context.Guild.Id);
			var owner = guild.Owner;
			string afkname = null;
			if (guild.AFKChannel != null)

			{ afkname = guild.AFKChannel.Name; }

			var embed = new EmbedBuilder();
			embed.WithTitle("Server Info");
			embed.AddField(guild.Name, guild.CreatedAt.ToString("dd'/'MM'/'yyyy hh:mm:ss tt"));
			embed.WithColor(240, 98, 146);
			embed.WithThumbnailUrl(guild.IconUrl);
			embed.AddField("› Owner", owner.ToString(), inline: true); //Server Owner.
			embed.AddField("› Members", guild.MemberCount.ToString(), inline: true); //User Count.
			embed.AddField("› Bots", $"{gusersbotonly.Count()}", inline: true); //Bot Count.
			embed.AddField("› Verification Level", guild.VerificationLevel.ToString(), inline: true); //Level Of Server Verification.
			embed.AddField("› Shard ID", Context.Client.ShardId, inline: true); // Shard ID.
			embed.AddField("› Text Channels", guild.TextChannels.Count.ToString(), inline: true);//Text Channel Count.
			embed.AddField("› Voice Channels", guild.VoiceChannels.Count.ToString(), inline: true); //Voice Channel Count.
			embed.AddField("› Region", guild.VoiceRegionId.ToString(), inline: true); //Region Of The Server.
			embed.AddField("› Roles", (guild.Roles.Count - 1).ToString(), inline: true); //How Many Roles The Server Has.
			embed.AddField("› Emoji", Context.Guild.Emotes.Count.ToString(), inline: true); //Emoji Count.
			embed.AddField("› Default Notifications", guild.DefaultMessageNotifications.ToString(), inline: true); // Personal
			int seconds = guild.AFKTimeout;
			string minutes = ((seconds % 3600) / 60).ToString();
			embed.AddField("› AFK Timeout", minutes + " minutes", inline: true); //AFK Timeout Set For The Server.
			embed.AddField("› AFK Channel", afkname ?? "None Set", inline: true); //AFK Channel For The Server.
			//embed.AddField("› Verified Guild", config.VerifiedGuild, inline: true);
			embed.WithFooter($"#{guild.Id.ToString()}"); //Footer Of The Embed As Unique Server ID 

			await Context.Channel.SendMessageAsync("", embed: embed.Build()); //Send The Embed Where The Command Was Excuted.
		 }
   }
 }
 
 
 //TODO: Imporve My BS Code. :D
