Getting Started
***************

So we are now in the 5ͭ ͪ  chapter and still did not write a single line of code (except the auto-generated ones). And we will postpone that even a bit further…

Documentation
=============

What? We *start* with documentation!? Of course! ☺ This gives us a direction for what to achieve and helps others to figure out what and especially *why* we did the things we did.\ [#You]_

Have a look at :doc:`goal` and :doc:`plan`. On the top-right of these pages there is a link :guilabel:`View page source`. There you can see how I 'programmed' this tutorial text. Add the diagrams from the *images* sub-directory to your *images* sub-directory and add them to your text. Describe how you understand your development process so far.

Also we need to prioritize the use cases. We know that we can build GUIs and that we can display images. Loading images is also a given. But the central use case *Save an animated GIF* is still an unknown. Do we need a GUI to do that? No. Do we need to manually load images for that? No, we can do this programmatically in a test.

Research
========

Man, still no coding. But we first need to find information about our most critical use case: actually writing the GIFs. As tempting as it might be to start with a really cool GUI\ [#TestDriven]_; it is much more sane to start with the mission critical part of your app. What if it would be ultra-complicated to achieve the desired goal …? And what would your boss think if you discovered that fact *after* putting two weeks development time in a very fancy GUI?

A quick check of the .Net framework libraries shows that WPF supports writing animated GIFs: ``GifBitmapEncoder`` from the ``System.Media.Windows.Imaging`` namespace. So are we done? No, because there is always a but… This encoder does not support adding metadata. And the repeat and frame-time information is metadata. The hints in the documentation point to the *Windows Imaging Component* and how to write a native encoder supporting metadata. That is a bit too much for our tutorial.

Looking further in the internet I found DataDink's abandoned BumpKit_. This library does more than just write animated GIFs, but it has a class which does exactly what we want: ``BumpKit.GifEncoder``. It relies on the ``System.Drawing`` namespace which might even make it possible using it in .Net standard 2.0 apps. We just take it as an inspiration due to issues with how it is implementing the ``IDisposable`` interface.

.. _BumpKit: https://github.com/DataDink/Bumpkit

With the most critical part being safe, we can finally start coding…

The Test
========

Thanks to BumpKit_ we know what to code. So we can start writing our test right away. If I am uncertain about the implementation I find test driven implementation quite awkward. I first prefer to play around in a programming playground like LINQPad_.

.. _LINQPad: https://www.linqpad.net/

At first we want to keep things simple and the restriction was equally sized (meaning *width* and *height*) images. Thus our ``AnimatedGifWriter`` needs to store a collection of ``Frame``\ s having the same size. Also these frames need a ``TimeSpan`` specifying how long this frame is to be displayed.

.. code-block:: csharp

   var writer = new AnimatedGifWriter();

   var frame = new Frame(imageFromSomewhereElse, TimeSpan.FromSeconds(.5));

   writer.Frames.Add(frame);

That is easy to do with a ``List<Frame>`` and a frame consisting of an ``Image`` and a ``TimeSpan``. But wait, ``System.Drawing.Image`` is derived from ``IDisposable``. So now we need to debate whether ``Frame`` owns the ``Image`` or just references it. Because if it owns the ``Image`` we also need to implement the ``IDisposable`` interface on ``Frame``.

For our purpose we store all ``Frame``\ s in the ``AnimatedGifWriter`` and thus it owns them. And the ``Frame`` owns the ``Image``. So we need to implement the ``IDisposable`` interface on all of them.

Here we need to start bottom up with the ``Frame``\ [#Source]_. The test driven loop starts like this:

1. Create a ``FrameTest`` class in the *TestStateMachineTutorial* project
2. Add a ``.CreateAndDispose()`` test method to it
3. Create a test image (for that we need to reference the *System.Drawing* assembly in both projects)
4. Call the Frame constructor with a chosen ``TimeSpan`` and the test image
5. As now compilation fails, create the ``Frame`` class in the *WpfStateMachineTutorial* project with the wanted constructor
6. Test that the test image is stored in the ``.Image`` property
7. As this does not compile implement the property and initialize it properly
8. …

When you did this, you have the happy path covered. Now ask yourself: "what could go wrong?" First write a test with the expected outcome (e.g. an ``ArgumentNullException`` for a missing ``Image`` object). Then write the checks into the constructor.

Coverage
========



.. rubric:: Footnotes

.. [#You] The *other* guy might as well be you in a few weeks…

.. [#TestDriven] And by the way: how do you want to develop test driven if the only thing you have is a GUI?

.. [#Source] See the actual test project for the implementation.
