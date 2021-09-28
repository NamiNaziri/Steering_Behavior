// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "BaseSteeringBehavior.h"
#include "SteeringBehavior_SeekAndFlee.generated.h"

/**
 * 
 */

UCLASS(Blueprintable)
class STEERINGPROJECT_API USteeringBehavior_SeekAndFlee : public UBaseSteeringBehavior
{
	GENERATED_BODY()
public:
	
	virtual FSteeringOutput GetSteering() override;
	//virtual bool IsCloseToTarget();
private:
	UPROPERTY(EditAnywhere)
		bool bFlee = false;
	UPROPERTY(EditAnywhere)
		float maxAcceleration = 2.5f;
};
