# Software Requirements Specification

## 1. Introduction

- **Project name:** Hotel Booking System  
- **Developer:** Vlad Barshak  
- **Technology stack:** FastAPI, SQLAlchemy, Pydantic, SQLite/PostgreSQL

This document defines the software requirements for the Hotel Booking System – a backend REST API for managing hotels, rooms, and reservations. It outlines the purpose, features, architecture, and technical constraints of the system.

---

## 2. The Purpose of the System

The purpose of this system is to automate the process of hotel room reservation. It allows hotel administrators to manage hotel and room information, while customers can view and book available rooms.

Key goals:
- Provide a clean and well-documented API for hotel and room management.
- Ensure reliable booking mechanisms with availability checks.
- Maintain modularity and scalability of the codebase.

---

## 3. Functional Requirements

| ID  | Requirement                                                             |
|-----|-------------------------------------------------------------------------|
| FR1 | The system shall allow administrators to add, edit, and delete hotels. |
| FR2 | The system shall allow administrators to add, edit, and delete rooms.  |
| FR3 | The system shall allow clients to view available rooms.                |
| FR4 | The system shall support booking of rooms.                             |
| FR5 | The system shall expose all functionalities via a REST API.            |
| FR6 | The system shall validate input data using Pydantic models.            |

---

## 4. Non-Functional Requirements

| ID  | Requirement                                                                 |
|-----|-----------------------------------------------------------------------------|
| NFR1| The system shall be developed using FastAPI.                                |
| NFR2| The system shall use SQLite (or PostgreSQL) for data persistence.           |
| NFR3| The API documentation shall be automatically generated via OpenAPI/Swagger. |
| NFR4| The source code shall be versioned with Git and hosted on GitHub.           |
| NFR5| The documentation shall be available via GitHub Pages.                      |

---

## 5. System Architecture

``` 
├── app/
│ ├── routes/ # API endpoints (hotels, rooms, booking)
│ ├── models/ # SQLAlchemy ORM models
│ ├── schemas/ # Pydantic models for validation
│ ├── services/ # Business logic
│ ├── utils/ # Utility functions
│ └── main.py # Entry point
├── database/ # DB configuration
├── requirements.txt # Dependencies
├── .env # Environment variables
└── docs/ # SRS and documentation
``` 

## 6. Data Models

### Hotel

| Field       | Type    | Description               |
|-------------|---------|---------------------------|
| id          | UUID    | Unique identifier         |
| name        | String  | Name of the hotel         |
| address     | String  | Hotel address             |
| stars       | Integer | Star rating (1–5)         |
| description | Text    | Description of the hotel  |

### Room

| Field        | Type    | Description                          |
|--------------|---------|--------------------------------------|
| id           | UUID    | Unique identifier                    |
| hotel_id     | UUID    | Foreign key to Hotel                 |
| room_number  | String  | Room number                          |
| type         | String  | Room type (e.g., single, double)     |
| price        | Float   | Price per night                      |
| is_available | Boolean | Availability status                  |

---

## 7. API Overview

- `GET /hotels` — Get list of hotels  
- `POST /hotels` — Create a new hotel  
- `GET /rooms` — Get list of rooms  
- `POST /rooms` — Create a new room  
- `GET /rooms/available` — Check available rooms  
- `POST /bookings` — Create a booking (planned)

All routes return JSON. API documentation available at `/docs`.

---

## 8. User Roles

| Role         | Description                                 |
|--------------|---------------------------------------------|
| Administrator| Manages hotel and room data via API         |
| Client       | Can browse and book rooms (read-only access)|

---

## 9. Limitations

- No frontend or mobile app provided  
- No user registration or authentication yet  
- No cancellation/modification of bookings  
- No payment integration  
- No email/SMS notifications

---

## 10. Glossary

- **API**: Application Programming Interface  
- **CRUD**: Create, Read, Update, Delete  
- **ORM**: Object Relational Mapping  
- **DTO**: Data Transfer Object (via Pydantic)  
- **UUID**: Universally Unique Identifier  