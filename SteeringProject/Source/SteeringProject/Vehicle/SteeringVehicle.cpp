// Fill out your copyright notice in the Description page of Project Settings.


#include "SteeringVehicle.h"
#include "BaseSteeringBehavior.h"
// Sets default values
ASteeringVehicle::ASteeringVehicle()
{
 	// Set this pawn to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	RootScene = CreateDefaultSubobject<USceneComponent>(TEXT("Scene"));
	SetRootComponent(RootScene);
	VehicleMesh = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("Vehicle Mesh"));
	VehicleMesh->SetupAttachment(RootComponent);
    
}

// Called when the game starts or when spawned
void ASteeringVehicle::BeginPlay()
{
	Super::BeginPlay();
    GetComponents<UBaseSteeringBehavior>(SteeringBehaviors);
}

// Called every frame
void ASteeringVehicle::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
    
    for (int i = 0; i < SteeringBehaviors.Num(); i++)
    {
        if (SteeringBehaviors[i] == nullptr )
            continue;
        GEngine->AddOnScreenDebugMessage(-1, GetWorld()->GetDeltaSeconds(), FColor::Magenta, "SteeringNum:  " + GetActorLocation().ToString());
        //GEngine->AddOnScreenDebugMessage(-1, GetWorld()->GetDeltaSeconds(), FColor::Magenta, "SteeringNum:  " + FString::FromInt(SteeringBehaviors.Num()));
        SetActorLocation(GetActorLocation() + velocity * DeltaTime);
        
        if (SteeringBehaviors[i]->IgnoreRotation)
        {
            if (velocity.SizeSquared() > 0)
                SetActorRotation(velocity.Rotation());
        	
        }
        else
        {
            orientation += rotation * DeltaTime;
            if (orientation < 0)
                orientation += 360;
            if (orientation > 360)
                orientation -= 360;

            ;
            FRotator NewActorRotation = FVector(FMath::Sin(FMath::DegreesToRadians<float>(orientation)),
												FMath::Cos(FMath::DegreesToRadians<float>(orientation)),
												0)
        										.Rotation();
            SetActorRotation(NewActorRotation);
                
        }
        
        FSteeringOutput output = SteeringBehaviors[i]->GetSteering();
    	
        velocity += output.linear * DeltaTime;
        rotation += output.angular * DeltaTime;

        //Return the object to the middle of the screen if it gets too far!
        /*if (transform.position.magnitude > 40)
        {
            transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
            transform.Rotate(Vector3.up, Random.Range(0.0f, 360.0f));

            velocity = Vector3.zero;
            rotation = 0;
        }*/
    }

}

// Called to bind functionality to input
void ASteeringVehicle::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

}

