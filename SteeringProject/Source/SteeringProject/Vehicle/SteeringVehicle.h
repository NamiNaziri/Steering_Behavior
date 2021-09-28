// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Pawn.h"
#include "SteeringVehicle.generated.h"


class UBaseSteeringBehavior;
UCLASS()
class STEERINGPROJECT_API ASteeringVehicle : public APawn
{
	GENERATED_BODY()

public:
	// Sets default values for this pawn's properties
	ASteeringVehicle();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

private:
	UPROPERTY(VisibleAnywhere)
	USceneComponent* RootScene;
	UPROPERTY(VisibleAnywhere)
	UStaticMeshComponent* VehicleMesh;

	UPROPERTY(EditAnywhere,Category = "Vehicle", meta = (AllowPrivateAccess = "true"))
	TArray<UBaseSteeringBehavior*> SteeringBehaviors;
	
	
	float orientation = 0;
	FVector velocity;
	float rotation;
	
};
