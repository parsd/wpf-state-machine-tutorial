Initial Project Setup
*********************

Documentation Project
=====================

We start simple by just setting up the *Sphinx* project. Open your *Explorer* and navigate to your project folder. In your folder press

:kbd:`Ctrl+Shift+N`

to create a new folder and name it *doc*.

Next select the newly created folder and then :kbd:`Shift+Right-Click` it to open the extended context menu and choose

:menuselection:`Open Command Prompt here`

Now we can start the Sphinx quickstart wizard:

.. code-block:: doscon

   $ sphinx-quickstart

The wizard will guide you through you project creation. The value in square brackets is the default which you can simply be typing :kbd:`Enter`. Configure your project like this (I omitted the explainatory texts):

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

Finally we test our newly created documentation project by reusing the *Command Prompt* where we started the ```sphinx-quickstart```:

.. code-block:: doscon

   $ make html

   [...]
   build succeeded.

   Build finished. The HTML pages are in build\html.

You can have a look at the generated *index.html* at *build\\html*.

To not have the generated files clutter our git project we update the *.gitignore* file at our project root (not the doc-root). Append the following to the end of the file:

.. code-block:: doscon

   # Sphinx build output
   doc/build/*/
