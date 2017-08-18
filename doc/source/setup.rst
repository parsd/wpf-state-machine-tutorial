Initial Project Setup
*********************

Create GitHub Project
=====================

Visual Studio WPF Project
=========================

After starting *Visual Studio* we can create a new WPF project:

   :menuselection:`File --> New --> Project…` or :kbd:`Ctrl+Shift+N`

In the now open wizard window we choose :guilabel:`Visual C#` on the left-hand-side. Then in the middle section we select :guilabel:`WPF App`. Finally we give our project a name: *WpfStateMachineTutorial* (same as GitHub project name). Depending on your settings you need to give the location where to place the project now or later when saving (:kbd:`Ctrl+Shift+S`). Use the parent directory of the GitHub project directory.

The last thing to consider depends on your taste on how to layout your project:

1. have a sub-directory for your project and files
2. solution and project in the same directory

I like flat hierarchies for simple projects like this one. Thus I chose option 2 (I disabled the checkbox :guilabel:`Create directory for solution`).

Test Project
------------

As we want to develop test driven we need a test project. Right-click on the solution in the :guilabel:`Solution Explorer` and select:

   :menuselection:`Add --> New Project…`

Choose :guilabel:`Console App`\ [#TestConsole]_ from the middle section and give it a name like: *TestStateMachineTutorial*. For our test app we use the *NUnit* framework. To add this package open:

   :menuselection:`Tools --> NuGet Package Manager --> Manage NuGet Packages for Solution…`

Make sure you are on the :guilabel:`Browse` tab and enter *NUnit* in the :guilabel:`Search` text box. Multi-select *NUnit* and *NUnitLight* by Charlie Poole. On the right-hand-side only check the box for *TestStateMachineTutorial* and hit :guilabel:`Install`.

*NUnitLight* will overwrite your *Program.cs* with the default test runner. This is exactly what we want.

Test
----

If you now hit :kbd:`Ctrl+F5` an empty window should be shown. Our first development steps won't need the GUI part, yet. So set *TestStateMachineTutorial* as the StartUp project. Right click on the project and select:

   :menuselection:`Set as StartUp Project`

After starting the app via :kbd:`Ctrl+F5` a console window should show up running *NUnitLight* reporting that no test cases are available.

First Commit
------------

This is a good time to stage and commit the newly created projects. As we used the predefined *.gitignore* file, we can simply stage all the listed files and commit them.

Documentation Project
=====================

We start simple by just setting up the *Sphinx* project. Open your *Explorer* and navigate to your project folder. In your folder press

   :kbd:`Ctrl+Shift+N`

to create a new folder and name it *doc*.

Next select the newly created folder and then :kbd:`Shift+Right-Click` it to open the extended context menu and choose

   :menuselection:`Open Command Prompt here`\ [#PowerShell]_

Now we can start the Sphinx quick start wizard:

.. code-block:: doscon

   $ sphinx-quickstart

The wizard will guide you through you project creation. The value in square brackets is the default which you can simply accept by typing :kbd:`Enter`. Configure your project like this (I omitted the explainatory texts):

.. code-block:: doscon

   > Root path for the documentation [.]:
   > Separate source and build directories (y/n) [n]: y
   > Name prefix for templates and static dir [_]:
   > Project name: WpfStateMachineTutorial
   > Author name(s): Your Name Here
   > Project version []: 0.1
   > Project release [0.1]:
   > Project language [en]:
   > Source file suffix [.rst]:
   > Name of your master document (without suffix) [index]:
   > Do you want to use the epub builder (y/n) [n]:
   > autodoc: automatically insert docstrings from modules (y/n) [n]:
   > doctest: automatically test code snippets in doctest blocks (y/n) [n]:
   > intersphinx: link between Sphinx documentation of different projects (y/n) [n]:
   > todo: write "todo" entries that can be shown or hidden on build (y/n) [n]:
   > coverage: checks for documentation coverage (y/n) [n]:
   > imgmath: include math, rendered as PNG or SVG images (y/n) [n]:
   > mathjax: include math, rendered in the browser by MathJax (y/n) [n]:
   > ifconfig: conditional inclusion of content based on config values (y/n) [n]:
   > viewcode: include links to the source code of documented Python objects (y/n) [n]:
   > githubpages: create .nojekyll file to publish the document on GitHub pages (y/n) [n]: y
   > Create Makefile? (y/n) [y]:
   > Create Windows command file? (y/n) [y]:

   Creating file .\source\conf.py.
   Creating file .\source\index.rst.
   Creating file .\Makefile.
   Creating file .\make.bat.

After the wizard has finished open *source\\conf.py* in an editor and search for

.. code-block:: python

   language = None

and change this to

.. code-block:: python

   language = 'en'

   highlight_language = 'csharp'

as we write an English text about a C# app. For now we finish editing by replacing

.. code-block:: python

   html_theme = 'alabaster'

with

.. code-block:: python

   html_theme = 'sphinx_rtd_theme'

Test
----

Finally we test our newly created documentation project by reusing the *Command Prompt* where we started the ```sphinx-quickstart```:

.. code-block:: doscon

   $ make html

   [...]
   build succeeded.

   Build finished. The HTML pages are in build\html.

You can have a look at the generated *index.html* at *build\\html*.

Commit
------

To not have the generated files clutter our git project we update the *.gitignore* file at our project root (not the doc-root). Append the following to the end of the file:

.. code-block:: doscon

   # Sphinx build output
   doc/build/*/

With this change we can again stage and commit all listed files.

.. rubric:: Footnotes

.. [#TestConsole] I prefer console test applications as they need less infrastructure (no runners/plugins and the like). I also find debugging easier and porting the project to other platforms. And maybe you guessed it by now: I like working on the console. ☺

.. [#PowerShell] If you have a current version of Windows 10 (version 1703 and above) you might not see the command prompt option, but *PowerShell* instead. The examples work also in the *PowerShell* command prompt. Only difference is if you execute scripts located inside your current folder. Instead of simply typing ``make html`` you need to enter:

   .. code-block:: doscon

      $ .\make.bat html

   *Hint:* simply type :kbd:`m` and then :kbd:`Tab` and *PowerShell* will expand it to ``.\make.bat``.
