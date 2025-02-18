﻿using ContactManager.Services;
using ContactManager.ApplicationOptions;
using ContactManager.Database;
using ContactManager.View;
using ContactManager.View.States;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ContactManager.Models;
using ContactManager.Repository;
using ContactManager.Services;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection(DatabaseOptions.SectionName)); 
builder.Services.Configure<ConsoleUIOptions>(options => options.StartingState = typeof(MainMenuState));
builder.Services.AddDbContext<ContactsDbContext>();
builder.Services.AddHostedService<DatabaseManagmentService>();
builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddHostedService<ConsoleUIService>();
builder.Services.AddTransient<IState, MainMenuState>();
builder.Services.AddTransient<IState, ExitState>();
builder.Services.AddTransient<IState, AddContactState>();
builder.Services.AddTransient<IState, ManageContactsState>();
builder.Logging.ClearProviders();
builder.Logging.AddDebug();
IHost host = builder.Build();
await host.RunAsync();