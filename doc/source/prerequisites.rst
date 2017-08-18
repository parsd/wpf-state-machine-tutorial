Prerequisites
*************

Before we can write our software, we have to have a few apps and packages installed.

Mandatory Apps
==============

- `Visual Studio <https://www.visualstudio.com>`_ (2017 was used for this tutorial) |br|
  Use e.g. Community Edition for personal/open source projects
- `Git for Windows <https://git-scm.com/download/win>`_ and `GitHub Desktop <https://desktop.github.com/>`_
- `Python <https://python.org>`_ (Python 3.6 was used for this tutorial) |br|
  Make sure that *pip* and *python* are in the ``PATH`` so we can start them directly from our command prompt.

Setup Python Packages
=====================

We need at least *sphinx* and the *read the docs* theme at the beginning. You could install the libraries in a virtual environment, but for simplicity we install the packages globally. Start a command line with administrator privileges:

   Press :guilabel:`Start` and then enter *cmd*. After that press :kbd:`Ctrl+Shift+Enter`.

In the now opened command line you can enter:

.. code-block:: doscon

   $ pip install sphinx
   $ pip install sphinx-rtd-theme

``$`` simply marks the command prompt location. If you do not have administrator privileges, then you can also install these libraries in you user's package directory. Add the ``--user`` option to the *pip install* calls.

Optional Apps
=============

Currently my preferred text editor is `Visual Studio Code <https://code.visualstudio.com/>`_. In this tutorial I used it for writing this documentation. For that task I also used the following extensions:

- David Anson's *markdownlint*
- Don Jayamanne's *Python*
- LeXtudio's *reStructuredText*
- Bartosz Antosik's *Spell Right*

And to be able to use the extensions fully, I installed the following packages via *pip*:

- *pylint*
- *restructuredtext-lint*

And for faster editing/review (see *tasks.json* in *.vscode* directory):

- *sphinx-autobuild*

.. |br| raw:: html

   <br />
