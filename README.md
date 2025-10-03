# AnyTravel Loyalty Service

Tracks and redeems loyalty points earned on completed bookings. One of the
~40 services already running on ECS Fargate — used in the Phase 0 workshop
as a "modernized" reference point next to `booking-api`.

## Running locally

```bash
dotnet restore
dotnet run --project src/LoyaltyService
```

## Testing

```bash
dotnet test
```

## Deployment

Container image built from the included `Dockerfile`, deployed to ECS
Fargate behind an ALB. See `infra/loyalty-svc.yaml`.
