//Player class for AR's Deathrun
//Made by Cruxeis, BL_ID 35041

function Player::doHeadUp(%this)
{
	for(%i = 1; %i < 4; %i++)
		%this.playThread(%i, "headUp");
}

function Player::stopHeadUp(%this)
{
	for(%i = 1; %i < 4; %i++)
		%this.stopThread(%i);
}