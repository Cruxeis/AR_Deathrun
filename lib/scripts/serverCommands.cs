//Server Commands for Agent Red's Deathrun
//Made by Cruxeis, BL_ID 35041

function serverCmdLlamaMe(%client)
{
	if(isObject(%player = %client.player))
		%player.changedatablock("LlamaArmor");
}

function serverCmdCloakMe(%client)
{
	if(isObject(%player = %client.player) && %client.getAdminLevel() > 1)
	{
		%player.changedatablock("PlayerHiddenArmor");
		%player.setShapeNameDistance(0);
	}
}

function serverCmdCowMe(%client)
{	
	if(isObject(%player = %client.player) && %client.getAdminLevel() > 1)
		%player.changedatablock("CowArmor");
}

function serverCmdUnhideNodeAll(%client)
{
	if(isObject(%player = %client.player) && %client.getAdminLevel() > 1)
	{
		%player.changedatablock("PlayerStandardArmor");
		%client.player.Unhidenode("ALL");
	}
}

function serverCmdEnergizeMe(%client)
{
	if(isObject(%player = %client.player) && %client.getAdminLevel() > 1)
		%player.changedatablock("PlayerQuakeArmor");
}

function serverCmdListMaps(%client)
{
	messageClient(%client, '', "\c2Map List");
	messageClient(%client, '', "\c3 1) \c6 MAP 1: Creative");
	messageClient(%client, '', "\c3 2) \c6 MAP 2: City");
	messageClient(%client, '', "\c3 3) \c6 MAP 3: Biomes");
	messageClient(%client, '', "\c3 4) \c6 MAP 4: Skylands");
}

function serverCmdQMT(%client)
{
	if(%client.getAdminLevel() > 0)
	{
		%client.player.setTransform("173 58.5 1.1");
		%client.player.setScale("1 1 1");
	}
}

//credit to AR for /help
function servercmdHelp(%client,%topic,%Staff)
{
	if(%topic $= "")
	{
		messageClient(%client, '', "\c6Please Choose a Topic. (Ex: /help Rules)");
		messageClient(%client, '', "\c0Rules\c6, \c1 About\c6, \c2 Commands\c6, \c3 KnownBugs\c6, \c4 Staff \c6, \c5 Credits");
		return;
	}
	if(%topic $= "rules")
	{
		messageClient(%client, '', "\c4Rules:");
        messageClient(%client, '', "\c61.  Do not cause needless arguments");
        messageClient(%client, '', "\c62.  Do not Ask/say you \"Need\" admin- We just wont just give admin, so please stop trying.");
        messageClient(%client, '', "\c63.  Do not spam (chat,musicbricks,emitters,lights, etc)");
        messageClient(%client, '', "\c64.  Play nicely");
		messageClient(%client, '', "\c65.  Do not cheat");
		messageClient(%client, '', "\c66.  Obey what the staff members say");
		messageClient(%client, '', "\c67.  Dont stall the game");
		messageClient(%client, '', "\c2Staff Rules");
		messageClient(%client, '', "\c61.) Do not change the Enviornmental Settings");
		messageClient(%client, '', "\c62.) Do not abuse your powers");
		messageClient(%client, '', "\c63.) Do not Un-Ban Anyone from the ban list");
		messageClient(%client, '', "\c64.) No trolling Around");
		messageClient(%client, '', "\c65.) Treat others/Lower level staff/Normal people equally");
		messageClient(%client, '', "\c66.) All normal server rules- Those still apply to you");
		messageClient(%client, '', "\c67.) No messing around with players while there Inside the game- This also counts as abusing your powers");
		messageClient(%client, '', "\c68.) Help those in need");
		return;
	}	
	if(%topic $= "About")
	{
		messageClient(%client, '', "\c3About \c6this server:");
		messageClient(%client, '', "\c61. Deathrun is a game�where players, called \c3Runners\c6 try to avoid the traps set�off by a�single�person, Aka \c8Death\c6. It is based off of skill and luck.");
		messageClient(%client, '', "\c6At the end, the Runners�challenge�the Death�to die");
		messageClient(%client, '', "\c62. This server was created by Agent Red, Rocket, K1ng S4vage, Chillah, Cruxeis, DatGuyT_T, Survival and Keeler");
		messageClient(%client, '', "\c63. For more information including an update log, staff applications, and map donations please join our <a:https://discord.gg/dwxqYXX>discord</a> \c6server");
		return;
	}
	if(%topic $= "Commands")
	{
		messageClient(%client, '', "\c6Commands:");
		messageClient(%client, '', "\c61. /Nojetsme- Turns you into a no-jets player");
		messageClient(%client, '', "\c62. /Llamame - Turns you into a llama");
		messageClient(%client, '', "\c63. /Trail- Custom trails for your player made by cruxeis");
		messageClient(%client, '', "\c64. /PM Name Message- Sends a Private message to the provided player");
		messageClient(%client, '', "\c65. /Help - this is where you are now");
		messageClient(%client, '', "\c66. /Spawn - Sends you to the lobby");
		messageClient(%client, '', "\c67. /Spec - Spectate whenever you want (you can also press your cancelbrick key to toggle this");
		return;
	}
	if(%topic $= "KnownBugs")
	{
		messageClient(%client, '', "\c61. When ever an administrator does /createland the ground looses collison for 0.1 of a second");
		messageClient(%client, '', "\c62. Sometimes the bricks will overlap (this is an engine issue, its not fixable)");
		messageClient(%client, '', "\c6No More Known bugs.. Please report any you find to an staff member");
	}
	if(%topic $= "Credits")
	{
		messageClient(%client, '', "\c2Credits:");
		messageClient(%client, '', "\c0 Agent Red(40251)\c6 - Server host, building, eventing, minor code");
		messageClient(%client, '', "\c3 Cruxeis(35041)\c6 - Main Coding");
		messageClient(%client, '', "\c3 Rocket(106288)\c6 - Building minor details");
		messageClient(%client, '', "\c1 Chillah(33252)\c6 - Eventing, building, extra details");
		messageClient(%client, '', "\c2 Keeler(48359)\c6 - Bug/Exploit finder, and minor details");
		messageClient(%client, '', "\c4 Survival(21120)\c6 - Building");
		messageClient(%client, '', "\c0 DatGuyT_T(172809)\c6 - minor building, trap ideas");
		messageClient(%client, '', "\c3 Heavy Bro(173273)\c6 - Building");
		messageClient(%client, '', "\c2 K1ng S4vage(94611)\c6 - Trap ideas, moral support");
		return;
	}
    if(%topic $= "Staff")
    {
        if(!%client.getAdminLevel())
		{
			messageClient(%client, '', "\c6Staff: ");
			messageClient(%client, '', "\c61. You are not staff, you can't view this"); 
			return;
		}
		if(!!%client.getAdminLevel())
		{
			messageClient(%client, '', "\c6 Please select a number \c2/help staff #");
			messageClient(%client, '', "\c21 -->\c6Secret Commands (1)");
			messageClient(%client, '', "\c22 -->\c6Punishment recommendations (2)");
			messageClient(%client, '', "\c23-->\c6Staff punishments (3)");
        }       
		if(%Staff == 1)
		{
			MessageClient(%client, '', "\c2Secret commands ");
			MessageClient(%client, '', "\c6/warn name reason- sends a warning to the specified person. Kicks on third time ");
			MessageClient(%client, '', "\c6/Normalme -gives you jets\c2(GM+");
			messageClient(%client, '', "\c6/A (Text Goes here) staff chat");
			messageClient(%client, '', "\c6/kill name - kills a player\c2(A+)");
			messageClient(%client, '', "\c6/LlamaMe - turns you into a llama\c2(GM+)");
			messageClient(%client, '', "\c6/CowMe - Turs you into a cow\c2(GM+)");
			messageClient(%client, '', "\c6/CloakMe- Turns you invisible\c2(GM+");
			messageClient(%client, '', "\c6/Unhidenodeall - Unhides all nodes\c2(GM+)");
			messageClient(%client, '', "\c6/EnergizeMe - Makes you go fast\c2(GM+)");
			messageClient(%client, '', "\c6/CreateLand - Creates a new ground 10,000 bricks in the air\c2(GM+)");
			messageClient(%client, '', "\c6/QMT - Teleports you to the Quick Map Teleporter");
			
        }
        if(%Staff == 2)
		{
      		messageClient(%client, '', "\c6Spamming(chat)- Warn first, Mute second, kick third");
			messageClient(%client,'', "\c6Asking for Admin persistently- Warn first, kick second");
			messageClient(%client,'', "\c6Being rude- punishment depends on the severity, do what you want (thats not stupid)");
			messageClient(%client,'', "\c6Spamming(Other)- clear Their bricks, and warn them. If done again, kick them");
			messageClient(%client,'', "\c6Cheating - punishment depends on severity, do what you want (BLHACK = Immediate perma ban)");
			messageClient(%client,'', "\c6Stalling - /kill, or kick them");
		}
		if(%Staff == 3)
		{
			messageClient(%client,'',"\c6Breaking a regular player rule - its breaking a rule, you get the punishment the non-staff player gets");
			messageClient(%client,'',"\c6Changing Enviornment - It breaks the server, Just dont do it, it breaks the server and its annoying as hell");
			messageClient(%client,'',"\c6Abusing powers - De-Admined");
			messageCLient(%client,'',"\c6Playing around with admin ablilites while in minigame(counts as abusing powers) - De-Admined");
			messageClient(%client,'',"\c6UN-BANNING - Ill get pissed..just dont do it please- Warned..");
			messageClient(%client,'',"\c6Trolling or abusing Eval -Warned");
			messageClient(%client,'',"\c6Not Treating others with respect - Warned");
			messageClient(%client,'',"\c3REMINDER\c6: All staff members get a total of two warnings before they get De-Admined..They do NOT reset");
		}	
	}
}

function serverCmdKill(%client, %target)
{
	%cName = %client.getPlayerName();
	if(!%client.getadminlevel())
	{
		writeToFile("config/server/AdminLogs/killLog.txt", "" @ %cName SPC "a/>" SPC %target);
		return messageClient(%client, '', "\c3You aren't staff");
	}
	if(!isObject(findClientbyName(%target)))
	{
		writeToFile("config/server/AdminLogs/killLog.txt", "" @ %cName SPC "c/>" SPC %target);
		return messageClient(%client, '', "\c3Invalid client.");
	}
	if(!isObject(%player = findClientbyName(%target).player))
	{
		writeToFile("config/server/AdminLogs/killLog.txt", "" @ %cName SPC "p/>" SPC %target);
		return messageClient(%client, '', "\c3Client does not have player object.");
	}
	else
	{
		%player.kill();
		messageClient(%client, '', "\c4" @ findClientbyName(%target).getPlayerName() SPC "\c3has been killed.");
		writeToFile("config/server/AdminLogs/killLog.txt", "" @ %cName SPC ">" SPC findClientbyName(%target).getPlayerName());
	}
}

function serverCmdCreateLand(%client)
{
	if(%client.isAdmin)
	{
		groundPlane.save("config/groundPlane.cs");
		groundPlane.setName("highGround");
		highGround.setTransform("0 0 4999.5");
		highGround.sendUpdate();
		exec("config/groundPlane.cs");
	}
}

function serverCmdSpawn(%client, %member)
{
    if(%client.slyrTeam.name $= "Runners" || %client.slyrTeam.name $= "Spectators")
		%client.removefromMini("Deathrun");
}

function serverCmdSpec(%client)
{
	if(%client.minigame == getMinigameByTitle(""))
	{
		%client.addToMini("Deathrun");
	}
	else if(%client.slyrTeam.name $= "Runners")
	{
		%client.player.kill();
	}
	else if(%client.slyrTeam.name $= "Death")
	{
		messageClient(%client, '', "\c3 You\c6 are\c7 Death\c6. You cannot spectate.");
	}
}

function serverCmdHeadUp(%client)
{
	if(isObject(%player = %client.player))
	{
		%player.headUp = !%player.headUp;
		if(%player.headUp)
		{
			for(%i = 1; %i < 4; %i++)
				%player.playThread(%i, "headUp");
		}
		else
		{
			for(%i = 1; %i < 4; %i++)
				%player.stopThread(%i);
		}
	}
}

function serverCmdChooseMap(%client, %map)
{
	if(%client.slyrTeam.name $= "Death")
	{
		if(isFile("config/rotatorMaps/" @ %map @ ".bls"))
		{
			if(%client.minigame.mapHasBeenChosen)
				return %client.centerPrint("\c3/chooseMap error\c6 - map has already been chosen", 2);
			else
			{
				rotator_loadMap(%map);
				%client.minigame.mapHasBeenChosen = true;
			}
		}
		else
			return %client.centerPrint("\c3/chooseMap error\c6 - that map doesn't exist.", 2);
	}
	else
		return %client.chatMessage("\c3/chooseMap error\c6 - access denied");
}

function serverCmdSetIMBrick(%client, %id)
{
	if(%client.getBLID() == 40251)
		$intermissionBrick = %id;
}

function serverCmdSetIMBiomes(%client, %id)
{
	if(%client.getBLID() == 40251)
		$biomesBrick = %id;
}

function serverCmdSetIMCity(%client, %id)
{
	if(%client.getBLID() == 40251)
		$CityBrick = %id;
}

function serverCmdSetIMSkylands(%client, %id)
{
	if(%client.getBLID() == 40251)
		$SkylandsBrick = %id;
}

function serverCmdConfirmShopBuy(%client)
{
	if(%client.hatToGrant !$= "")
	{
		%client.grantHat(%client.hatToGrant, 0, 1);
		%client.shopList = %player.client.shopList SPC %client.hatToGrant;
	}
	if(%client.itemToGrant !$= "")
	{
		%client.player.pickup(%client.itemToGrant);
		%client.shopList = %player.client.shopList SPC %client.itemToGrant;
	}
	%client.setScore(%client.score - %client.pointstotake);
	%client.hatToGrant = "";
	%client.itemToGrant = "";
}

function serverCmdSpy(%client, %victim)
{
	if(!%client.getAdminLevel())
		return;
	if(isObject(%victimPlayer = findClientByName(%victim).player))
	{
		%client.camera.setMode("Corpse", %victimPlayer);
		%client.setControlObject(%client.camera);
		%client.isSpying = true;
	}
	else
		return %client.chatMessage("Player not found");
}

function serverCmdKick(%client, %victim, %reason)
{
	if(!%client.getAdminLevel())
		return;
	if(isObject(%target = findClientByName(%victim)))
	{
		if(%client.getAdminLevel() < %target.getAdminLevel())
			return %client.chatMessage("\c3You can't kick someone higher than you");
		%target.delete();
		messageAll('', "\c3" @ %client.getPlayerName() SPC "\c2kicked \c3" @ %target.getPlayerName() SPC "\c2(ID:" SPC %target.getBLID() @ ")");
	}
}

function serverCmdFind(%client, %victim)
{
	if(!%client.getAdminLevel())
		return;
	if(isObject(%target = findClientByName(%victim).player))
	{
		%client.player.setTransform(%target.getTransform());
		%client.player.teleportEffect();
	}
}

function serverCmdFetch(%client, %victim)
{
	if(%client.getAdminLevel() < 2)
		return;
	if(isObject(%target = findClientByName(%victim).player))
	{
		%target.setTransform(%client.player.getTransform());
		%client.player.teleportEffect();
	}
}

function serverCmdWarp(%client)
{
	if(%client.getAdminLevel() < 2)
		return;
	%start = %client.player.getEyePoint();
	%end = VectorAdd(%start, VectorScale(%client.player.getEyeVector(), 512));
	%raycast = ContainerRayCast(%start, %end, -1, %client.player);
	if(isObject(%raycast))
		%final = posFromRayCast(%raycast);
	%client.player.setTransform(%final);
	%client.player.teleportEffect();
}

function serverCmdMute(%client, %victim, %time)
{
	if(!%client.getAdminLevel())
		return;
	if(%time > 16)
	{
		%client.chatMessage("\c3You can't mute someone for more than \c016 minutes.");
		serverCmdMute(%client, %victim, 16);
		return;
	}
	if(isObject(%target = findClientByName(%victim)))
	{
		if(!%target.isMuted)
		{
			%target.isMuted = true;
			%target.muteLength = %time * 1000 * 60;
			%target.chatMessage("\c3You have been muted for \c0" @ %time SPC "minutes.");
			%target.unMuteSched = %target.schedule(%target.muteLength, setAttribute, "isMuted", false);
			%target.unMutePrintSched = %target.schedule(%target.muteLength, chatMessage, "\c3You can talk now.");
			%client.chatMessage("\c3You have muted \c2" @ %target.getPlayerName() SPC "\c3for \c0" @ %time SPC "minutes.");
		}
		else
		{
			%client.chatMessage("\c3That person has already been muted for \c0" @ (%target.muteLength / 1000 / 60) SPC "minutes.");
			%client.chatMessage("\c3They have \c0" @ (getTimeRemaining(%target.unMuteSched) / 1000 / 60) SPC "minutes \c3remaining.");
		}
	}
	else
		return %client.chatMessage("\c3Mute error - invalid victim!");
}

function serverCmdUnMute(%client, %victim)
{
	if(!%client.getAdminLevel())
		return;
	if(isObject(%target = findClientByName(%victim)))
	{
		if(%target.isMuted)
		{
			cancel(%target.unMuteSched);
			cancel(%target.unMutePrintSched);
			if(isEventPending(%target.unMuteVarSched))
			{
				cancel(%target.unMuteVarSched);
				$Pref::Server::Mute[%target.getBLID()] = false;
				$Pref::Server::MuteLengthRemaining[%target.getBLID()] = 0;
			}
			%target.isMuted = false;
			%target.chatMessage("\c3You have been unmuted.");
		}
		else
			return %client.chatMessage("\c3That person is not muted!");
	}
	else
		return %client.chatMessage("\c3Unmute error - invalid victim!");
}

function serverCmdWarn(%client, %victim, %reason0, %reason1, %reason2, %reason3, %reason4, %reason5, %reason6, %reason7, %reason8, %reason9, %reason10, %reason11, %reason12, %reason13, %reason14, %reason15, %reason16, %reason17)
{
	if(!%client.getAdminLevel())
		return;
	for(%i = 0; %i < 18; %i++)
		%reason = %reason SPC %reason[%i];
	if(isObject(%target = findClientByName(%victim)))
	{
		if(%target.getAdminLevel() > 1)
			return %client.chatMessage("\c3Warn error - this person can't be warned.");
		writeToFile("config/warnings.txt", getDateTime() TAB %target.totalWarnings TAB %client.getPlayerName() SPC %client.getBLID() TAB %target.getPlayerName() SPC %target.getBLID() TAB %reason);
		if(%target.totalWarnings == 2)
		{
			messageAll('', "\c3" @ %client.getPlayerName() SPC "\c2kicked" SPC "\c3" @ %target.getPlayerName() SPC "\c2(ID:" SPC %target.getBLID() @ ")");
			%target.delete();
		}
		else
		{
			%target.totalWarnings++;
			%client.chatMessage("\c3You have \c0warned \c3" @ %target.getPlayerName() SPC "\c3for \c0" @ %reason); 
			%target.chatMessage("\c3You have been \c0warned: \c6" @ %reason);
			%target.chatMessage("\c3This is warning \c0" @ %target.totalWarnings @ ". \c3You will be kicked on warning 3.");
		}
	}
	else
		return %client.chatMessage("\c3Warn error - That person does not exist.");
}

function serverCmdGiveMod(%client, %victim)
{
	if(%client.getAdminLevel() < 6)
		return;
	if(isObject(%target = findClientByName(%victim)))
	{
		if(!%target.isModerator)
		{
			messageAll('MsgAdminForce', "\c3" @ %target.getPlayerName() SPC "\c2has become \c4Moderator");
			%target.isModerator = true;
			$Pref::Server::Moderator[%target.getBLID()] = true;
		}
		else
			return %client.chatMessage("\c3GiveMod error - that person is already a moderator.");
	}
	else
		return %client.chatMessage("\c3GiveMod error - that person does not exist.");
}

function serverCmdTakeMod(%client, %victim)
{
	if(!(%client.isGlobalModerator || %client.isCoHost || %client.isHost))
		return;
	if(isObject(%target = findClientByName(%victim)))
	{
		if(%target.isModerator)
		{
			messageAll('MsgError', "\c3" @ %target.getPlayerName() SPC "\c2is no longer \c4Moderator");
			%target.isModerator = false;
			$Pref::Server::Moderator[%target.getBLID()] = false;
		}
		else
			return %client.chatMessage("\c3TakeMod error - that person is not a moderator.");
	}
	else
		return %client.chatMessage("\c3TakeMod error - that person does not exist.");
}

function serverCmdGiveDev(%client, %victim)
{
	if(%client.getAdminLevel() < 6)
		return;
	if(isObject(%target = findClientByName(%victim)))
	{
		if(!%target.isDeveloper)
		{
			messageAll('MsgAdminForce', "\c3" @ %target.getPlayerName() SPC "\c2has become \c1Developer");
			%target.isDeveloper = true;
			$Pref::Server::Developer[%target.getBLID()] = true;
		}
		else
			return %client.chatMessage("\c3GiveDev error - that person is already a developer.");
	}
	else
		return %client.chatMessage("\c3GiveDev error - that person does not exist.");
}

function serverCmdTakeDev(%client, %victim)
{
	if(%client.getAdminLevel() < 6)
		return;
	if(isObject(%target = findClientByName(%victim)))
	{
		if(%target.isDeveloper)
		{
			messageAll('MsgAdminForce', "\c3" @ %target.getPlayerName() SPC "\c2is no longer \c1Developer");
			%target.isDeveloper = false;
			$Pref::Server::Developer[%target.getBLID()] = false;
		}
		else
			return %client.chatMessage("\c3TakeDev error - that person is not a developer.");
	}
}

function serverCmdStaffShutdown(%client)
{
	if(%client.getAdminLevel() < 6)
		return;
	else
	{
		messageAll('MsgClearBricks', "\c3Server is being shut down for maintenance...");
		messageAll('', "\c23");
		schedule(1000, 0, messageAll, '', "\c32");
		schedule(2000, 0, messageAll, '', "\c01");
		schedule(3000, 0, staffShutdown);
	}
}

function serverCmdPM(%client, %victim, %word0, %word1, %word2, %word3, %word4, %word5, %word6, %word7, %word8, %word9, %word10, %word11, %word12, %word13, %word14, %word15, %word16, %word17)
{
	for(%i = 0; %i < 18; %i++)
		%message = trim(%message SPC %word[%i]);
	if(isObject(%target = findClientByName(%victim)))
	{
		%client.chatMessage("\c2You \c6> \c1" @ %target.getPlayerName() @ "\c3:" SPC %message);
		%target.chatMessage("\c1" @ %client.getPlayerName() SPC "\c6> \c2You\c3:" SPC %message);
		echo(getDateTime() SPC %client.getPlayerName() SPC ">" SPC %target.getPlayerName() SPC %message);
		writeToFile("config/PMLog.txt", getDateTime() TAB %client.getPlayerName() TAB %target.getPlayerName() TAB %message);
	}
	else
		%client.chatMessage("\c3PM Error - person does not exist");
}

function serverCmdNormalMe(%client)
{
	if(%client.getAdminLevel() < 3 || isObject(%client.miniGame))
		return;
	if(isObject(%player = %client.player))
	{
		%player.unHideNode("headSkin");
		%player.changeDatablock("PlayerStandardArmor");
		%player.setScale("1 1 1");
		commandToClient(%client, 'setPaintingDisabled', false);
		commandToClient(%client, 'setBuildingDisabled', false);
		commandToClient(%client, 'setPlayingInMinigame', false);
		%client.buildingDisabled = false;
	}
}

function serverCmdNoJetsMe(%client)
{
	if(isObject(%player = %client.player))
		%player.changeDatablock("PlayerNoJet");
}

function serverCmdSetSpawnSphereRadius(%client, %radius)
{
	if(%client.isSuperAdmin)
	{
		$Pref::Server::DiffSpawnSphere::Radius = %radius;
		playerDropPoints.getObject(0).radius = %radius;
		messageAll('', "\c4" @ %client.getPlayerName() SPC "\c3set the Spawn Sphere Radius to\c2" SPC %radius);
	}
}

function serverCmdSetSpawnSphereTransform(%client, %transform0, %transform1, %transform2)
{
	if(%client.isSuperAdmin)
	{
		%a = %transform0 SPC %transform1 SPC %transform2;
		$Pref::Server::DiffSpawnSphere::Transform = %a;
		playerDropPoints.getObject(0).setTransform(%a);
		messageAll('', "\c4" @ %client.getPlayerName() SPC "\c3set the Spawn Sphere Transform to\c2" SPC %a);
	}
}

//not made by me or AR
function serverCmdA(%client, %arg1, %arg2, %arg3, %arg4, %arg5, %arg6, %arg7, %arg8, %arg9, %arg10, %arg11, %arg12, %arg13, %arg14, %arg15, %arg16, %arg17)
{
    if(!%client.isAdmin || %client.isModerator || %client.isGlobalModerator)
        return;
    for(%i = 1; %i < 18; %i++)
        %sentence = %sentence SPC %arg[%i];
	%sentence = adminChatPrepString(%sentence);
    %groupCount = clientGroup.getCount();
    for(%i = 0; %i < %groupCount; %i++)
    {
        if((%target = clientGroup.getObject(%i)).isAdmin || %client.isModerator || %client.isGlobalModerator)
            messageClient(%target, '', "\c2StaffChat(\c4" @ %client.getPlayerName() @ "\c2)\c2: \c3" @ %sentence);
    }
}

//also not made by me or AR
function serverCmdDev(%client, %arg1, %arg2, %arg3, %arg4, %arg5, %arg6, %arg7, %arg8, %arg9, %arg10, %arg11, %arg12, %arg13, %arg14, %arg15, %arg16, %arg17)
{
    if(!%client.isDeveloper)
        return;
    for(%i = 1; %i < 18; %i++)
        %sentence = %sentence SPC %arg[%i];
	%sentence = adminChatPrepString(%sentence);
    %groupCount = clientGroup.getCount();
    for(%i = 0; %i < %groupCount; %i++)
    {
        if((%target = clientGroup.getObject(%i)).isDeveloper)
            messageClient(%target, '', "\c2DevChat(\c4" @ %client.getPlayerName() @ "\c2)\c2: \c3" @ %sentence);
    }
}

package ARDeathrun_ServerCommandsPackage {

function serverCmdMessageSent(%client, %message)
{
	if(%client.isMuted)
		return %client.chatMessage("\c3You are still muted with \c0" @ (getTimeRemaining(%client.unMuteSched) / 1000 / 60) SPC "minutes \c3remaining.");
	else
		return Parent::serverCmdMessageSent(%client, %message);
}

function serverCmdUseInventory(%client, %slot)
{
	if(%client.buildingDisabled)
		return;
	else
		Parent::serverCmdUseInventory(%client, %slot);
}

function serverCmdMissionStartPhase3ACK(%client, %bool)
{
	if(%client.getBLID() == getNumKeyID())
	{
		if(isObject(%sphere = playerDropPoints.getObject(0)))
		{
			%sphere.radius = $Pref::Server::DiffSpawnSphere::Radius;
			%sphere.setTransform($Pref::Server::DiffSpawnSphere::Transform);
			return parent::serverCmdMissionStartPhase3ACK(%client, %bool);
		}
	}
	return parent::serverCmdMissionStartPhase3ACK(%client, %bool);
}

function serverCmdCancelBrick(%client)
{
	Parent::serverCmdCancelBrick(%client);
	serverCmdSpec(%client);
}

};

activatePackage(ARDeathrun_ServerCommandsPackage);