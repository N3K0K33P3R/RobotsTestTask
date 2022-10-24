# Robots Test Task
Task is implemented in the RobotsBackend project. 
Given input example is implemented in the integration test, but you can run RobotTestTask to try it yourself.

# Robot creating process
Robot creating process is made by using a builder pattern, so it is quite simple to add a new type of robot and new build process options. Moreover, it can easily be expanded to support new formats of input just by implementing IRobotsBuilderDirector.

# Commands
Commands are implemented with a command pattern. The sender is an abstract InputHandler (ConsoleInputHandler in current realization). The receiver is a robot. I’ve decided to implement all business logic inside commands, so a robot is just a model without  business logic. Input handler creates commands using CommandsFactory, which is also abstract, so adding new ways to pass commands to service is also easy. In addition to that, it’s pretty easy to add new commands by implementing the ICommand interface and adding it to the factory. 

# Input handling
Input handling is also made easily replaceable. At the moment only console input is implemented. There is also an environment factory that creates all needed objects for input handling like specific input parsers, etc. It is also not tied to a specific console, it is quite easy to implement another one, which was done in the integration test. 

# Evaluation of the implementation of the entire solution
I assume it would take around 5 days to implement it, including business analyst work, code review, testing and bug fixing.
