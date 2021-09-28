// Copyright Epic Games, Inc. All Rights Reserved.

#include "SteeringProjectGameMode.h"

#include "UObject/ConstructorHelpers.h"

ASteeringProjectGameMode::ASteeringProjectGameMode()
{
	// use our custom PlayerController class
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnBPClass(TEXT("/Game/TopDownCPP/Blueprints/TopDownCharacter"));
	if (PlayerPawnBPClass.Class != nullptr)
	{
		DefaultPawnClass = PlayerPawnBPClass.Class;
	}
}