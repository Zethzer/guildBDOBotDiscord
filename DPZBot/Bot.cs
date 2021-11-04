using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace DPZBot
{
    internal class Bot
    {
        DiscordClient discord;

        public Bot()
        {
            discord = new DiscordClient();
            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            // Commands
            var commands = discord.GetService<CommandService>();
            commands.CreateCommand("aide").Alias(new string[] { "help" } ).Do(async (e) =>
            {
                await e.Channel.SendMessage("**!dpz warnode** - Gestion des warnodes\n**!dpz guilde <site | elephant | voilier>** - Site de la guilde et autres pour la guilde\n**!dpz cuisine** - Site pour la cuisine\n**!dpz database <en | fr>** - Site de la base de donnée de *Black Desert Online*\n**!dpz map <1 | 2>** - Sites de maps\n**!dpz alchimie <1 | 2 | 3 | pierre>** - Sites pour l'alchimie\n**!dpz enchant <1 | 2 | tableau | cristaux>** - Sites pour l'enchantement\n**!dpz guide <awaktamer | dk | bdo>** - Sites de guides pour les classes et le jeu\n**!dpz progression <leveling | contrib | inventaire | amitie>** - Sites pour la progression dans le jeu\n**!dpz divers** - Sites divers par rapport à *Black Desert Online*\n**!dpz bonus** - Surprise !");
            });

            commands.CreateGroup("dpz", cgb => {
                cgb.CreateCommand("warnode").Do(async (e) =>
                {
                    await e.Channel.SendMessage("https://www.blackdesertonline.com/game/warfare/");
                });

                cgb.CreateCommand("guilde").Parameter("arg", ParameterType.Optional).Do(async (e) =>
                {
                    if (e.GetArg("arg") == "site")
                        await e.Channel.SendMessage("http://divisionparzero.guildi.com/fr/m/profil/2-Divisionparzero");
                    else if (e.GetArg("arg") == "elephant")
                        await e.Channel.SendMessage("http://bddatabase.net/fr/item/9916/");
                    else if (e.GetArg("arg") == "voilier")
                        await e.Channel.SendMessage("http://bddatabase.net/fr/item/9906/");
                    else
                        await e.Channel.SendMessage("site - http://divisionparzero.guildi.com/fr/m/profil/2-Divisionparzero \nelephant - http://bddatabase.net/fr/item/9916/ \nvoilier http://bddatabase.net/fr/item/9906/");
                });

                cgb.CreateCommand("map").Parameter("arg", ParameterType.Optional).Do(async (e) =>
                {
                    if (e.GetArg("arg") == "1")
                        await e.Channel.SendMessage("http://www.somethinglovely.net/bdo/");
                    else if (e.GetArg("arg") == "2")
                        await e.Channel.SendMessage("http://www.blackdesertfoundry.com/map/#4/-8.89/-25.22");
                    else
                        await e.Channel.SendMessage("1 - http://www.somethinglovely.net/bdo/ \n2 - http://www.blackdesertfoundry.com/map/#4/-8.89/-25.22");
                });

                cgb.CreateCommand("database").Parameter("arg", ParameterType.Optional).Do(async (e) =>
                {
                    if (e.GetArg("arg") == "en")
                        await e.Channel.SendMessage("http://bddatabase.net/us/");
                    else if (e.GetArg("arg") == "fr")
                        await e.Channel.SendMessage("http://bddatabase.net/fr/?sl=1");
                    else
                        await e.Channel.SendMessage("en - http://bddatabase.net/us/ \nfr - http://bddatabase.net/fr/?sl=1");
                });

                cgb.CreateCommand("cuisine").Do(async (e) =>
                {
                    await e.Channel.SendMessage("http://www.black-desert-online.fr/cuisine-metiers-bdo-black-desert-online-fr.php");
                });

                cgb.CreateCommand("alchimie").Parameter("arg", ParameterType.Optional).Do(async (e) =>
                {
                    if (e.GetArg("arg") == "1")
                        await e.Channel.SendMessage("http://bdo.jiji-family.com/achimie.bdo");
                    else if (e.GetArg("arg") == "2")
                        await e.Channel.SendMessage("http://www.blackdesertfoundry.com/all-recipes/#tab-alchemy-recipes2");
                    else if (e.GetArg("arg") == "3")
                        await e.Channel.SendMessage("https://docs.google.com/document/d/1erv28NDPWRa2BC8qFYmbuOwftjMmgDJgaXtw-qjXZtg/edit#");
                    else if (e.GetArg("arg") == "pierre")
                        await e.Channel.SendMessage("http://www.blackdeserttome.com/guides/viewtext?id=11");
                    else
                        await e.Channel.SendMessage("1 - http://bdo.jiji-family.com/achimie.bdo \n2 - http://www.blackdesertfoundry.com/all-recipes/#tab-alchemy-recipes2 \n3 - https://docs.google.com/document/d/1erv28NDPWRa2BC8qFYmbuOwftjMmgDJgaXtw-qjXZtg/edit# \npierre - http://www.blackdeserttome.com/guides/viewtext?id=11");
                });

                cgb.CreateCommand("enchant").Parameter("arg", ParameterType.Optional).Do(async (e) =>
                {
                    if (e.GetArg("arg") == "1")
                        await e.Channel.SendMessage("https://www.reddit.com/r/blackdesertonline/comments/5gzhox/alexmac_gear_enchant_guide_get_those_tets_boys/");
                    else if (e.GetArg("arg") == "2")
                        await e.Channel.SendMessage("https://docs.google.com/spreadsheets/d/1WzAeIFslcWhZ-TudUTrvt4S6ejGF8Uo5FwVqNivfHK0/pubhtml");
                    else if (e.GetArg("arg") == "tableau")
                        await e.Channel.SendMessage("http://i.imgur.com/G7Aw641.png");
                    else if (e.GetArg("arg") == "cristaux")
                        await e.Channel.SendMessage("https://alphaoptix.github.io/bdocrystalz/");
                    else
                        await e.Channel.SendMessage("1 - https://www.reddit.com/r/blackdesertonline/comments/5gzhox/alexmac_gear_enchant_guide_get_those_tets_boys/ \n2 - https://docs.google.com/spreadsheets/d/1WzAeIFslcWhZ-TudUTrvt4S6ejGF8Uo5FwVqNivfHK0/pubhtml \ntableau - http://i.imgur.com/G7Aw641.png \ncristaux https://alphaoptix.github.io/bdocrystalz/");
                });

                cgb.CreateCommand("guide").Parameter("arg", ParameterType.Optional).Do(async (e) =>
                {
                    if (e.GetArg("arg") == "awaktamer")
                        await e.Channel.SendMessage("http://forum.blackdesertonline.com/index.php?/topic/118948-guide-awake-tamer-tu-veux-voir-mon-gros-b%C3%A2ton-termin%C3%A9/");
                    else if (e.GetArg("arg") == "dk")
                        await e.Channel.SendMessage("https://docs.google.com/document/d/1T17a2ujyZcdsuFHuTxGHARzKNKyXD8qSZx6eXO1PW2E/edit");
                    else if (e.GetArg("arg") == "bdo")
                        await e.Channel.SendMessage("http://forum.blackdesertonline.com/index.php?/forum/43-guides-et-tutoriels/");
                    else
                        await e.Channel.SendMessage("awaktamer - http://forum.blackdesertonline.com/index.php?/topic/118948-guide-awake-tamer-tu-veux-voir-mon-gros-b%C3%A2ton-termin%C3%A9/ \ndk - https://docs.google.com/document/d/1T17a2ujyZcdsuFHuTxGHARzKNKyXD8qSZx6eXO1PW2E/edit \nbdo - http://forum.blackdesertonline.com/index.php?/forum/43-guides-et-tutoriels/");
                });

                cgb.CreateCommand("progression").Parameter("arg", ParameterType.Optional).Do(async (e) =>
                {
                    if (e.GetArg("arg") == "leveling")
                        await e.Channel.SendMessage("http://forum.blackdesertonline.com/index.php?/topic/287-1-60-leveling-guide/");
                    else if (e.GetArg("arg") == "contrib")
                        await e.Channel.SendMessage("http://www.blackdeserttome.com/guides/viewtext?id=1");
                    else if (e.GetArg("arg") == "inventaire")
                        await e.Channel.SendMessage("https://docs.google.com/spreadsheets/d/10hHbShPIf02IZYHS7pj0vYnnxq7WmPAl2I6o8ev69GU/edit#gid=0");
                    else if (e.GetArg("arg") == "amitie")
                        await e.Channel.SendMessage("https://bdotools.com/");
                    else
                        await e.Channel.SendMessage("leveling - http://forum.blackdesertonline.com/index.php?/topic/287-1-60-leveling-guide/ \ncontrib - http://www.blackdeserttome.com/guides/viewtext?id=1 \ninventaire - https://docs.google.com/spreadsheets/d/10hHbShPIf02IZYHS7pj0vYnnxq7WmPAl2I6o8ev69GU/edit#gid=0 \namitie - https://bdotools.com/");
                });

                cgb.CreateCommand("divers").Do(async (e) =>
                {
                    await e.Channel.SendMessage("https://blackdesert.zendesk.com/hc/fr/articles/210761289-Fichiers-Corrompus");
                });

                cgb.CreateCommand("bonus").Do(async (e) =>
                {
                    await e.Channel.SendMessage("https://e-hentai.org/?f_doujinshi=0&f_manga=0&f_artistcg=0&f_gamecg=0&f_western=0&f_non-h=0&f_imageset=0&f_cosplay=1&f_asianporn=0&f_misc=0&f_search=&f_apply=Apply+Filter");
                });
            });

            // Connexion to discord
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("secret", TokenType.Bot);
                discord.SetGame("Dites !aide");
            });
        }
    }
}
