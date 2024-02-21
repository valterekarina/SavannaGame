using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Savanna.GameLogic;
using Savanna.GameLogic.Interfaces;

IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IRandom, StepRandom>();
                    services.AddSingleton<IUserInputHandler, UserInputHandler>();
                    services.AddSingleton<IField, Field>();
                    services.AddSingleton<ISavannaGame, SavannaGame>();
                    services.AddTransient<IGetAnimal, GetAnimal>();
                    services.AddTransient<IMoveAnimalRun, MoveAnimalRun>();
                    services.AddTransient<IMoveAnimalCatch, MoveAnimalCatch>();
                    services.AddTransient<IGetInput, UserInputHandler>();
                    services.AddTransient<IAnimalHealth, AnimalHealth>();
                    services.AddSingleton<IAnimalBirth, AnimalBirth>();
                    services.AddTransient<IConsoleFacade, ConsoleFacade>();
                    services.AddSingleton<IConstants, Constants>();

                }).Build();

ActivatorUtilities.CreateInstance<SavannaGame>(host.Services).Run();

host.Run();
