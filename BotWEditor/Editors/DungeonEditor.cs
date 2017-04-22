using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BotWLib.Formats;
using System.IO;

namespace BotWEditor.Editors
{
    class DungeonEditor
    {
        public SARC RootArchive;

        public void LoadFromStream(Stream sarcStream)
        {
            RootArchive = new SARC(sarcStream);
        }


        // Sanity checks can be to look for Dungeon files specifically.

        /*
        * `Actor`
            * `Pack`
                * `DgnMrgPrt_Dungeon000.sbactorpack`
        * `Map`
            * `CDungeon`
                * `Dungeon000`
                    * `Dungeon000_Clustering.sblwp`
                    * `Dungeon000_Dynamic.smubin`
                    * `Dungeon000_Static.smubin`
                    * `Dungeon000_TeraTree.sblwp`
            * `DungeonData`
                * `CDungeon`
                    * `Dungeon000.bdgnenv`
        * `Model`
            * `DgnMrgPrt_Dungeon000.sbfres`
            * `DgnMrgPrt_Dungeon000.Tex2.sbfres`
        * `NavMash`
            * `CDungeon`
                * `Dungeon000`
                    * `Dungeon000.shknm2`
        * `Physics`
            * `StaticCompound`
                * `CDungeon`
                    * `Dungeon000.shksc`
        */
    }
}
