// Fill out your copyright notice in the Description page of Project Settings.


#include "BaseSteeringBehavior.h"
#include "SteeringVehicle.h"
// Sets default values
UBaseSteeringBehavior::UBaseSteeringBehavior()
{
}

// Called when the game starts or when spawned
void UBaseSteeringBehavior::BeginPlay()
{
	Super::BeginPlay();
	Character = Cast<ASteeringVehicle>( GetOwner());
}


FSteeringOutput UBaseSteeringBehavior::GetSteering()
{
	FSteeringOutput Output;
	Output.linear = FVector::ZeroVector;
	Output.angular = 0;
	return Output;
}

bool UBaseSteeringBehavior::IsCloseToTarget()
{
	return bIsClose;
}

