// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "BaseSteeringBehavior.generated.h"


USTRUCT(BlueprintType)
struct FSteeringOutput
{
	GENERATED_BODY()
	
		UPROPERTY()
		FVector linear;
		UPROPERTY()
		float angular;
};

class ASteeringVehicle;

UCLASS(Blueprintable)
class STEERINGPROJECT_API UBaseSteeringBehavior : public UActorComponent
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	UBaseSteeringBehavior();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	virtual FSteeringOutput GetSteering();
	virtual bool IsCloseToTarget();
	
public:
	
	ASteeringVehicle* Character;
	
	UPROPERTY(EditAnywhere)
		ASteeringVehicle* Target;
	UPROPERTY(EditAnywhere)
	bool IgnoreRotation = true;
	UPROPERTY(EditAnywhere)
	float MaxReachDistance = 5.f;
	UPROPERTY(EditAnywhere)
	bool bIsClose = false;
};
