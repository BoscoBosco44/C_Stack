Enemy badGuy = new Melee();

Attack facePunch = new Attack("Face Punch", 7);
Attack stab = new Attack("Stab", 11);
Attack nuke = new Attack("Nuke", 10000);

badGuy.AddAttack(facePunch);
badGuy.AddAttack(stab);
badGuy.AddAttack(nuke);

//---------------------------------------------------

Enemy MeleeMan = new Melee();
Enemy SniperSam = new Ranged();
Enemy MagicMaster = new Magic();

MeleeMan.PreformAttack(SniperSam, MeleeMan.AttackList{Kick});