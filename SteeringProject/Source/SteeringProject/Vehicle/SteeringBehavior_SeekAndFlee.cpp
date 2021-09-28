// Fill out your copyright notice in the Description page of Project Settings.


#include "SteeringBehavior_SeekAndFlee.h"

#include "SteeringVehicle.h"

FSteeringOutput USteeringBehavior_SeekAndFlee::GetSteering()
{
	FSteeringOutput SteeringOutput;
	SteeringOutput.linear = FVector::ZeroVector;
	SteeringOutput.angular = 0;
	if(Target)
	{
		SteeringOutput.linear = Target->GetActorLocation() - Character->GetActorLocation();
		if(bFlee)
		{
			SteeringOutput.linear *= -1;
		}

		SteeringOutput.linear.Z = 0;
		SteeringOutput.linear.Normalize();
		SteeringOutput.linear *= maxAcceleration;
	}

	return SteeringOutput;
}
