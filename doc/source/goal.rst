The Goal
********

In this tutorial we want to create something *awesome*: an animated GIF creator! …

Yeah, if you are as old as I am, this sounds weird ☺. GIFs were totally uncool by the end of the last millennium due to its LZW software patent issues. I was burning to be able to use PNGs, but couldn’t, because the back then ubiquitous Internet Explorer didn’t support them fully. It did with version 7. And that version was released in 2006 (and still not widely used, because it shipped with Windows Vista). And by then, the software patent was void for two years. So you can imagine that convincing my boss to use PNGs was hard, especially as we shipped our product documentation as CHM files… I think you can imagine my astonishment, when my wife asked me whether I heard about this brand new thing: GIFs!

This revelation is now a few years old and back then animated GIFs had the air of the blink-tag for me. But I am still teachable…, so yes, there are valid use cases for these. Then without further ado let’s get started. What do we want to be able to do?

.. figure:: /images/use_cases.svg
   :align: center

   Use case diagram for our GIF creator\ [#uc-src]_

.. rubric:: Footnotes

.. [#uc-src] PlantUML_ source code:

   .. code-block:: doscon

      @startuml
      left to right direction
      User --> (Load images)
      User --> (Configure animation)
      User --> (Preview animation)
      User --> (Save animated gif)
      @enduml

.. _PlantUML: http://plantuml.com/
