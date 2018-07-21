//Armor class for AR's Deathrun
//Made by Cruxeis, BL_ID 35041

package ARDeathrun_ArmorPackage {

function Armor::onTrigger(%this, %player, %slot, %val)
{
	if(%slot == 0 && %val && %player.getMountedImage(0) == 0)
	{
		%start = %player.getEyePoint();
		%end = VectorScale(%player.getEyeVector(), 5);
		%mask = $TypeMasks::ItemObjectType;
		%rayCast = ContainerRayCast(%start, VectorAdd(%start, %end), %mask, %player);
		%item = firstWord(%rayCast);
		if(!isObject(%item))
			return Parent::onTrigger(%this, %player, %slot, %val);
		%datablock = %item.getDatablock();
		%itemName = %datablock.getName();
		%brickName = %item.spawnBrick.getName();
		%points = getSubStr(%brickName, 1, strlen(%brickName));
		%client = %player.client;
		if(%client.score < %points)
		{
			%player.client.chatMessage("\c3You do not have enough points to purchase this item, you need \c0" @ %points - %player.client.score SPC "\c3more.");
			return Parent::onTrigger(%this, %player, %slot, %val);
		}
		if(getSubStr(%itemName, 0, 3) $= "Hat")
		{
			%name = getSubStr(%itemName, 3, strlen(%itemName) - 11);
			%client.hatToGrant = %name;
			commandToClient(%client, 'MessageBoxYesNo', "Confirmation", "Are you sure you would like to buy the" SPC %name SPC "hat for" SPC %points SPC "points?", 'confirmShopBuy');
		}
		else
		{
			%client.itemToGrant = %item;
			commandToClient(%client, 'MessageBoxYesNo', "Confirmation", "Are you sure you would like to buy the" SPC %item.getDatablock().uiName SPC "for" SPC %points SPC "points?", 'confirmShopBuy');
		}
		%client.pointstotake = %points;
		return Parent::onTrigger(%this, %player, %slot, %val);
	}
	else
		return Parent::onTrigger(%this, %player, %slot, %val);
}

};

activatePackage(ARDeathrun_ArmorPackage);