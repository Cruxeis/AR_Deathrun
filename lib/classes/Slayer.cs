//Slayer_MinigameSO class functions for AR's Deathrun
//Made by Cruxeis, BL_ID 35041

function Slayer_TeamSO::getNumLiving(%team)
{
	if(%team.numMembers == 0)
		return 0;
	%count = %team.numMembers;
	for(%i = 0; %i < %count; %i++)
	{
		if(isObject(%team.member[%i].player))
			%num++;
	}
	if(%num == 0 || %num $= "")
		return "0";
	else return %num;
}	

function Slayer_MinigameSO::getTeam(%mini, %team)
{
	%count = %mini.teams.getCount();
	for(%i = 0; %i < %count; %i++)
	{
		if(%mini.teams.getObject(%i).name $= %team)
			return %mini.teams.getObject(%i);
	}
}

function Slayer_MinigameSO::changeTeamDatablock(%this, %team, %datablock)
{
	%team = %this.getTeam(%team);
	%count = %team.numMembers;
	for(%i = 0; %i < %count; %i++)
		%team.member[%i].player.changeDatablock(%datablock);
}

function Slayer_MinigameSO::chooseRandPlayer(%this, %transform)
{
	if(%this.title !$= "Deathrun")
		return;
	%count = %this.numMembers;
	%rand = getRandom(0, (%count - 1));
	%client = %this.member[%rand];
	%client.spawnPlayer();
	%client.player.setTransform(%transform);
}

function Slayer_MinigameSO::allJoinTeam(%this, %team)
{
	%count = %this.numMembers;
	for(%i = 0; %i < %count; %i++)
		%this.member[%i].joinTeam(%team);
}

package ARDeathrun_SMgSOPackage {

function Slayer_MinigameSO::addMember(%mini, %member)
{
	Parent::addMember(%mini, %member);
	cancel($printPointsSched);
	printPointsLoop();
}

function Slayer_MinigameSO::onReset(%mini)
{
	Parent::onReset(%mini);
	cancel($printPointsSched);
	printPointsLoop();
}

function Slayer_MiniGameSO::onReset(%mini, %client)
{
	%mini.mapHasBeenChosen = false;
	%runners = %mini.getTeam("Runners");
	%runners.centerPrintAll("<just:left>\c6Please wait as the death chooses a map.");
	return Parent::onReset(%mini, %client);
}

function Slayer_MiniGameSO::endRound(%obj, %a1, %a2, %a3, %a4, %a5, %a6)
{
	Parent::endRound(%obj, %a1, %a2, %a3, %a4, %a5, %a6);
	%id = getNumKeyID();
	brickGroup_888888.chainDeleteAll();
	$intermissionBrick.setColliding(true);
	$intermissionBrick.setRendering(true);
	$intermissionBrick.setRayCasting(true);
	$biomesBrick.setColliding(true);
	$biomesBrick.setRendering(true);
	$biomesBrick.setRayCasting(true);
	$cityBrick.setColliding(true);
	$cityBrick.setRendering(true);
	$cityBrick.setRayCasting(true);
	$skylandBrick.setColliding(true);
	$skylandsBrick.setRendering(true);
	$skylandsBrick.setRayCasting(true);

}

function Slayer_MiniGameSO::startRound(%obj, %a1, %a2, %a3, %a4, %a5, %a6)
{
    Parent::startRound(%obj, %a1, %a2, %a3, %a4, %a5, %a6);
    %runners = %obj.getTeam("Runners");
    %count = %runners.numMembers;
    for(%i = 0; %i < %count; %i++)
        %runners.member[%i].player.schedule(5000, setTransform, "220 -40.5 2.1");
}

};

activatePackage(ARDeathrun_SMgSOPackage);