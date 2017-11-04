Prerequisites
*************

Before we can write our software, we have to have a few apps and packages installed.

Mandatory Apps
==============

For *Visual Studio* and *Git for Windows* at least you need to have administrative permissions. *Python* can also be installed for your account only.

- `Visual Studio <https://www.visualstudio.com>`_ (2017 was used for this tutorial) |br|
  Use e.g. Community Edition for personal/open source projects
- `Git for Windows <https://git-scm.com/download/win>`_ and `GitHub Desktop <https://desktop.github.com/>`_
- `Python <https://python.org>`_ (Python 3.6 was used for this tutorial) |br|
  Make sure that *pip* and *python* are in the ``PATH`` so we can start them directly from our command prompt.

Setup Python Packages
=====================

We need at least *Sphinx* and the *Read the Docs* theme at the beginning (dependencies for the documentation project). You could install the packages in a virtual environment, but for simplicity we install the packages globally. Start a command line with administrator privileges:\ [#PipUser]_

   Press :guilabel:`Start` and then enter *cmd*. After that press :kbd:`Ctrl+Shift+Enter`.

We install our *Python* dependencies via *pip* from the `Python Package Index <https://pypi.python.org>`_ (*PyPI*). In the now opened command line window you can enter:

.. code-block:: doscon

   > pip install sphinx
   > pip install sphinx-rtd-theme

``>`` marks the command prompt location where you can enter text.

Optional Apps
=============

Currently my preferred text editor is `Visual Studio Code <https://code.visualstudio.com/>`_. In this tutorial I used it for writing this documentation. For that task I also used the following extensions:

- David Anson's *markdownlint*
- Don Jayamanne's *Python*
- LeXtudio's *reStructuredText*
- Bartosz Antosik's *Spell Right*

And to be able to use the extensions fully, I installed the following packages via *pip* globally:

- *pylint*
- *restructuredtext-lint*

And for faster editing/review:

- *sphinx-autobuild*

See *tasks.json* in the *.vscode* directory for the corresponding build task.

.. rubric:: Footnotes

.. [#PipUser] If you do not have administrator privileges, then you can also install packages to your user's package directory. Add the ``--user`` option to the *pip install* calls.

.. |br| raw:: html

   <br />
