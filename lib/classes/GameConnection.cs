//GameConnection class for AR's Deathrun
//Made by Cruxeis, BL_ID 35041

function GameConnection::saveScore(%client)
{
	%score = %client.score;
	%file = new fileObject();
	%file.openForWrite("config/server/savedScores/" @ %client.bl_id @ ".txt");
	%file.writeLine(%score);
	%file.close();
	%file.delete();
}

function GameConnection::loadScore(%client)
{
	%file = new fileObject();
	%file.openForRead("config/server/savedScores/" @ %client.bl_id @ ".txt");
	%score = %file.readLine();
	%client.setScore(%score);
	%file.close();
	%file.delete();
}

function GameConnection::setBuildingDisabled(%client, %bool)
{
	%client.buildingDisabled = %bool;
	commandToClient(%client, 'setBuildingDisabled', %bool);
}

function GameConnection::setPaintingDisabled(%client, %bool)
{
	commandToClient(%client, 'setPaintingDisabled', %bool);
}
	
function GameConnection::removeFromMini(%this)
{
	if(isObject(%mini = %this.minigame))
		%mini.removeMember(%this);
}

function GameConnection::addToMini(%this, %title)
{
	if(isObject(%mini = getMinigameByTitle(%title)))
		%mini.addMember(%this);
}

function GameConnection::teleportSlayerTeam(%this, %team, %transform)
{
	%teamcount = %this.minigame.teams.getCount();
	for(%i = 0; %i < %teamcount; %i++)
	{
		if(%this.minigame.teams.getObject(%i).name !$= %team)
			continue;
		else
		{
			%playercount = %this.minigame.teams.getObject(%i).numMembers;
			for(%j = 0; %j < %playercount; %j++)
			{
				if(isObject(%individual = %this.minigame.teams.getObject(%i).member[%j].player))
				{
					%individual.setTransform(VectorAdd(%transform, getRandom(0, 3) SPC getRandom(0, 3) SPC "0"));
				}
			}
		}
	}
}

function GameConnection::loadEnvironment(%this, %env)
{
	rotator_loadEnvironment(%env);
}

function GameConnection::getAdminLevel(%this)
{
	if(%this.isHost) return 7;
	if(%this.isCoHost) return 6;
	if(%this.isDeveloper) return 5;
	if(%this.isSuperAdmin) return 4;
	if(%this.isAdmin) return 3;
	if(%this.isGlobalModerator) return 2;
	if(%this.isModerator) return 1;
	else return 0;
}

package ARDeathrun_GCPackage {

function GameConnection::autoAdminCheck(%this)
{
	if(%this.getBLID() == getNumKeyID() || %this.isLocal())
		%this.isHost = true;
	if($Pref::Server::CoHost == %this.getBLID())
	{
		%this.isCoHost = true;
		messageAll('', "\c3" @ %this.getPlayerName() SPC "\c2has become \c3Co-Host");
	}
	if($Pref::Server::Developer[%this.getBLID()])
	{
		%this.isDeveloper = true;
		messageAll('', "\c3" @ %this.getPlayerName() SPC "\c2has become \c1Developer");
	}
	if($Pref::Server::GlobalModerator == %this.getBLID())
	{
		%this.isGlobalModerator = true;
		messageAll('', "\c3" @ %this.getPlayerName() SPC "\c2has become Global Moderator");
	}
	if($Pref::Server::Moderator[%this.getBLID()])
	{
		%this.isModerator = true;
		messageAll('', "\c3" @ %this.getPlayerName() SPC "\c2has become \c4Moderator");
	}
	if($Pref::Server::Mute[%this.getBLID()])
	{
		%this.isMuted = true;
		%this.muteLength = $Pref::Server::MuteLengthRemaining[%this.getBLID()];
		%target.unMuteSched = %target.schedule(%target.muteLength, setAttribute, "isMuted", false);
		%target.unMutePrintSched = %target.schedule(%target.muteLength, chatMessage, "\c3You can talk now.");
		%target.unMuteVarSched = schedule(%target.muteLength, 0, eval, "$Pref::Server::Mute[" @ %this.getBLID() @ "]=false;");
		%this.chatMessage("\c3You still have \c0" @ getTimeRemaining(%this.unMuteSched) / 1000 / 60 SPC "minutes \c3left on your mute.");
	}
	return Parent::autoAdminCheck(%this);
}

function GameConnection::onClientLeaveGame(%this, %a, %b, %c)
{
	if(%this.isMuted)
	{
		$Pref::Server::Mute[%this.getBLID()] = true;
		$Pref::Server::MuteLengthRemaining[%this.getBLID()] = getTimeRemaining(%this.unMuteSched);
	}
	Parent::onClientLeaveGame(%this, %a, %b, %c);
}

};

activatePackage(ARDeathrun_GCPackage);