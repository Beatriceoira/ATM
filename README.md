# ATM Banking System

A desktop ATM simulation developed in **C# and WPF** as an Object-Oriented Programming project.

The application simulates common ATM operations, including account authentication, balance inquiries, deposits, and withdrawals. It uses a graphical user interface built with Windows Presentation Foundation (WPF).

This is a school project for OOP. This was made when I was a 2nd year, it was primarily assigned to us so we can learn WPF in the span of 4 weeks. 

## Features

* PIN-based account authentication
* Balance inquiry
* Cash deposit
* Cash withdrawal
* Transaction receipts
* Transaction logging
* Graphical user interface
* Object-oriented C# design
* Multiple account support

## Technologies Used

* **C#**
* **.NET**
* **WPF (Windows Presentation Foundation)**
* **XAML**
* **Visual Studio**
* **Object-Oriented Programming**

## Project Structure

```text
ATM/
│
├── atm/
│   ├── Account.cs
│   ├── App.xaml
│   ├── App.xaml.cs
│   ├── MainWindow.xaml
│   ├── MainWindow.xaml.cs
│   ├── PinWindow.xaml
│   ├── PinWindow.xaml.cs
│   ├── BalanceWindow.xaml
│   ├── BalanceWindow.xaml.cs
│   ├── DepositWindow.xaml
│   ├── DepositWindow.xaml.cs
│   ├── WithdrawWindow.xaml
│   ├── WithdrawWindow.xaml.cs
│   ├── App.config
│   │
│   ├── Properties/
│   │   ├── AssemblyInfo.cs
│   │   ├── Resources.Designer.cs
│   │   ├── Resources.resx
│   │   ├── Settings.Designer.cs
│   │   └── Settings.settings
│   │
│   └── CAPITALISMLOGO-removebg-preview.png
│
├── FINALS_OOP_OIRA.sln
├── README.md
└── .gitignore
```

## Application Flow

```text
Start Application
       │
       ▼
   PIN Screen
       │
       ▼
 Authenticate Account
       │
       ▼
   Main Menu
   ┌───┼────┬───────┐
   ▼   ▼    ▼       ▼
Balance Deposit Withdraw Exit
   │    │      │
   └────┴──────┘
          │
          ▼
   Transaction Log
          │
          ▼
        Receipt
```

## ATM Operations

### Authentication

Users enter their account credentials through the PIN window. The application validates the account before allowing access to ATM functions.

### Balance Inquiry

Users can view their current account balance.

### Deposit

Users can enter an amount to deposit into their account. The account balance is updated after a successful transaction.

### Withdrawal

Users can enter an amount to withdraw. The application checks the available balance before completing the transaction.

### Transaction Records

The application generates transaction information such as logs and receipts during runtime.

Runtime-generated transaction files are excluded from version control using `.gitignore`.

## Object-Oriented Programming Concepts

This project demonstrates several fundamental OOP concepts:

* **Classes and Objects** — accounts and application components are represented using C# classes.
* **Encapsulation** — account-related data and operations are managed within appropriate classes.
* **Methods** — banking operations such as deposits and withdrawals are implemented as methods.
* **Abstraction** — the graphical interface hides the underlying banking operations from the user.
* **Event-Driven Programming** — WPF button and window events control application behavior.

## How to Run

### Requirements

* Windows
* Visual Studio 2022 or later
* .NET SDK compatible with the project

### Steps

1. Clone the repository:

```bash
git clone <your-repository-url>
```

2. Open:

```text
FINALS_OOP_OIRA.sln
```

in Visual Studio.

3. Restore the project dependencies if prompted.

4. Build the solution:

```text
Build → Build Solution
```

5. Run the application:

```text
Debug → Start Without Debugging
```

or press:

```text
Ctrl + F5
```

## Security Notice

This application is an **educational ATM simulation** and is not intended for real financial transactions.

Do not use real banking credentials, PINs, or sensitive financial information with the application.

## Future Improvements

Potential future improvements include:

* Password/PIN hashing
* Database-backed account storage
* Account creation
* Transfer between accounts
* Transaction history interface
* Improved input validation
* PIN retry limits and account lockout
* Administrative account management
* Improved UI/UX
* Unit testing
* Secure database integration

## Author

**Beatrice Oira**

C# / Object-Oriented Programming Project
