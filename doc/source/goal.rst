The Goal
********

In this tutorial we want to create something *awesome*: an animated GIF creator! …

Yeah, if you are as old as I am, this sounds weird ☺. GIFs were totally uncool by the end of the last millennium due to its LZW software patent issues. I was burning to be able to use PNGs, but couldn’t, because the back then ubiquitous Internet Explorer didn’t support them fully. It did with version 7. And that version was released in 2006 (and still not widely used, because it shipped with Windows Vista). And by then, the software patent was void for two years. So you can imagine that convincing my boss to use PNGs was hard, especially as we shipped our product documentation as CHM files… I think you can imagine my astonishment, when my wife asked me whether I heard about this brand new thing: GIFs!

This revelation is now a few years old and back then animated GIFs had the air of the blink-tag for me. But I am still teachable…, so yes, there are valid use cases for these. Then without further ado let’s get started. What do we want to be able to do?

.. figure:: /images/use_cases.svg
   :align: center

   Use case diagram for our GIF creator\ [#uc-src]_

Ok, that doesn't look too bad. If we want to create an animated GIF we first need some images. And we need to bring them in a certain order so the animation makes sense. Also the speed of the animation is important and if it should repeat itself. After we settled on all of this, our configuration is done and we want to preview our work. And finally we want to save the product of our work.

But … is it sensible to be able to load new images while we save the new GIF? Lets put everything in an activity diagram to give it some structure. And also we want to be more specific with the *Configure animation* use case as hinted above:

.. figure:: /images/activities.svg
   :align: center

   Activity diagram for our GIF creator\ [#activity-src]_

I split the *Configure animation* use case into *configure speed*, *configure repeats*, and *reorder images* (if possible) activities. Also I partitioned the activities into three groups (which nearly resemble the use cases):

Configuration
   Enables the user to provide the data and arrange it according to her wishes.

Preview
   Check if the *Configuration* fits the user's expectation.

Saving
   Finally store the fruits of the user's work.

The title of this tutorial spoils it a bit, but these sections will become the states of our state machine ☺. I also kept the diagram relatively simple for this tutorial. Normally there would also be a repeat after the *Preview* section back to the *Configuration* section if we are not happy with the preview. Program exit is also possible everywhere. And what about errors …? Nah, nothing will ever go wrong! ☺

.. rubric:: Footnotes

.. [#uc-src] PlantUML_ source code for use case diagram:

   .. code-block:: doscon

      @startuml
      left to right direction
      User --> (Load images)
      User --> (Configure animation)
      User --> (Preview animation)
      User --> (Save animated gif)
      @enduml

.. [#activity-src] PlantUML_ source code for activity diagram:

   .. code-block:: doscon

      @startuml
      start

      partition Configuration {
        repeat
          split
            :configure speed;
          split again
            :configure repeats;
          split again
            :load image;
          split again
            if (multiple images?) then (yes)
              :reorder images;
            else (no)
            endif
          end split
        repeat while (more data?)
      }

      partition Preview {
        :show animation;
      }

      partition Saving {
        :enter filename;
        :save gif;
      }

      stop
      @enduml

.. _PlantUML: http://plantuml.com/
