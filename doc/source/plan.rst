Always have a Plan
******************

.. epigraph::

   Weeks of programming can save you hours of planning. |br|
   -- unknown

So let's make one. First on the meta layer we want to create a solid_, MVVM_ structured application with our development being `driven by tests <https://en.wikipedia.org/wiki/Test-driven_development>`_. In the spirit of `single responsibilities <https://en.wikipedia.org/wiki/Single_responsibility_principle>`_ I prefer the view models to be just decorating_ the models. And to have a nice story from the use cases/activities to the tests, I like to focus on behaviors_. I know, with all that we have a full plate – and to make things worse: I am a lazy developer: `I like the compiler to do the work for me so I make fewer mistakes <http://www.aristeia.com/Papers/IEEE_Software_JulAug_2004_revised.htm>`_.

.. _solid: https://en.wikipedia.org/wiki/SOLID_(object-oriented_design)

.. _MVVM: https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel

.. _decorating: https://en.wikipedia.org/wiki/Decorator_pattern

.. _behaviors: https://en.wikipedia.org/wiki/Behavior-driven_development

As we have no customer waiting and the GUI is not that important, we can be relaxed and build the app from the bottom up. So we safe the time to create a visual prototype. Thus, let’s focus first on the models – where the actual work is done!

Interlude: What not to Achieve
==============================

|yinyang|

In :doc:`goal` we talked about what we want to achieve – and when. But a good programmer should be an optimistic pessimist, a good natured realist. A pure optimist will produce an app with a very narrow happy path. A pure pessimist wouldn’t get anything done; and if it got done, it would be dull.

We just want to write an app that simply creates animated GIFs -- nothing more. So we don't want image editing capabilities and to keep it simple no undo stack. Often programmers want to put too much in an app, which then does a lot of things … not so well. Also this often hides the idea behind the app and hinders the work flow. Think of browsers: they are our new operating systems. But you only see an address box a few buttons and a burger menu when you start.

The Law of Murphy
=================

.. epigraph::

   Anything that can go wrong will go wrong |br|
   -- Edward A. Murphy jr.

Now we swap our hats and think about what could go wrong: What definitely shouldn't happen is that the app crashes when it hits a bump. Also mutating into a zombie on a hiccup is also a no no. Off the top of my head, I can think of the following undesirables:

* File not found
* File not an image
* Image has differing size
* Save location is not writable
* Save location has not enough disk space
* Out of memory (tough)

After this quick brain storming session we can prepare and incorporate failure into our implementation!

Models
======

.. figure:: /images/model_overview.svg
   :align: center

   Overview class diagram for our models\ [#model-cd]_

All of the above classes and namespaces except ``Stateless`` reside in the ``WpfStateMachineTutorial`` namespace. Our main class is ``GifCreator`` which also owns via associations the three state objects. To keep the diagram readable I left out the aggregation of the three state types by the ``StateMachine<TState,TTrigger>``. Only the ``ConfigState`` is special as this is additionally aggregated via its interface. I omitted the application namespace for readability reasons. I also renamed the **Saving** group from the activities into ``Serialization`` (more programmer dialect). There will be more classes and interfaces in the end, but this should suffice to get started.

But why …?
------------

… did I what I did? Let's start abstract:

First
   I am always strongly voting for the model layer to be self-sufficient. So it doesn't matter whether we want to use it in a command line tool, a GUI or on the server to drive some web-site. And as stated above, we postpone the work on the UI related parts.

   I used namespaces to separate our three major use cases. This is to separate the concerns on a high level, which enables us to quickly find and place functionality. Putting everything in namespaces like ``Model``, ``View`` or ``ViewModel`` is good for SDKs related to building GUIs, but not for the application. I prefer to put patterns or roles in the type names.

Second
   If you look at the typical Stateless_ examples, they set up the state machine quite differently from what I plan to do. In our app we have different states and not all data is valid in each state. With the typical enumeration based approach we need to guard data that is invalid in certain states (reading from/writing to such an attribute should throw an exception). But if we use different types that only consist of the valid data, we safe us and our users some work.

   What we will implement here is the 'C#isation' of a state machine implementation with a C++ variant_. This then brings us back to 'make fewer mistakes'.

.. _variant: https://www.youtube.com/watch?v=ojZbFIQSdl8&t=810s

Third
   You need to have third, don't you? Ok, if you insist: I try to have flat class hierarchies. Deep hierarchies yield more rigid, hard to understand code and introduce more work for us to do if we need to derive a new type. Also we always must keep to Liskov substitution principle\ [#liskov]_ to not surprise us in the future. Also deep hierarchies make it hard to achieve the open-closed principle. And you don't need to derive a type to achieve openness to changes; it is just one option.

.. _LoD: https://en.wikipedia.org/wiki/Law_of_Demeter

State Machine
~~~~~~~~~~~~~

Now lets be more concrete: first why did I use a state machine library (*Stateless*) and thus state machines at all? In our case the activity diagram showed that we have three major states our app can be in. Using a state machine conveys that idea directly in code. Every state takes its responsibility and only has its necessary data and operations (separation of concerns).

Isn't using extra state types overly complicated? I need the right type to access my data … Exactly that's why. We use the type system to protect us from mistakes -- force us to think about our actions. And reduces the amount of checks we have to write.

Often state machines live hidden in the code making it hard to understand why some operations are currently not possible. Also the state transitions are spread over a large area. This gives us more opportunity to make mistakes. And as I state above: I am lazy -- here I invest a little more work to keep me from doing much, much more work in the end.

Use of the Interfaces ``IState`` and ``IConfig``
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

The reason behind ``IState`` is quickly explained: it is simply there to give the three state objects its role in our app. ``IConfig`` grants the read only interface to the ``ConfigState`` used all over our app. Changes are only permitted if the app is in the ``ConfigState``.

I don't use much more interfaces as dependency inversion can also be achieved by other means. We will see that in the implementation sections. There are similar options available as with the open-closed principle.

.. rubric:: Footnotes

.. [#model-cd] PlantUML_ source code for model overview class diagram:

   .. code-block:: doscon

      @startuml

      class GifCreator

      class Stateless.StateMachine<TState, TTrigger>

      interface IState <<interface>>

      interface Configuration.IConfig <<interface>>
      class Configuration.ConfigState

      class Preview.PlayerState

      class Serialization.AnimatedGifWriter
      class Serialization.WriterState

      Configuration.IConfig <|-- Configuration.ConfigState

      Serialization.WriterState o-- "1" Serialization.AnimatedGifWriter

      GifCreator o-- "1" Configuration.IConfig
      GifCreator o-- "1" Stateless.StateMachine
      GifCreator o-right- IState : current
      (GifCreator, IState) . Stateless.StateMachine

      IState <|-up- Configuration.ConfigState
      IState <|-- Serialization.WriterState
      IState <|-right- Preview.PlayerState

      hide empty members
      hide class circle
      hide interface circle

      @enduml

.. _PlantUML: http://plantuml.com/

.. _Stateless: https://github.com/dotnet-state-machine/stateless

.. [#liskov] Liskov substitution principle put simply is that derived types are a base type: is-a relationship.

.. |br| raw:: html

   <br />

.. |yinyang| raw:: html

   <center><a title="By Gregory Maxwell [Public domain], via Wikimedia Commons" href="https://commons.wikimedia.org/wiki/File%3AYin_yang.svg"><img width="64" alt="Yin yang" src="https://upload.wikimedia.org/wikipedia/commons/thumb/1/17/Yin_yang.svg/64px-Yin_yang.svg.png"/></a></center>
