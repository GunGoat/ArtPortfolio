using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoreSeedDataToTestGallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Starry Night is one of Vincent van Gogh's most famous paintings. It depicts the night sky over Saint-Rémy-de-Provence in swirling patterns of light and color. The bright stars and crescent moon contrast with the dark, rolling hills and the sleepy village below, capturing Van Gogh's unique style and emotional intensity.");

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Sunflowers is a series of still-life paintings by Vincent van Gogh. These paintings depict sunflowers in various stages of life, from budding to withering. Van Gogh's use of vibrant yellows and textured brushstrokes captures the vitality and beauty of these flowers, showcasing his mastery of color and composition.");

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "The Bedroom is a series of three paintings by Vincent van Gogh. This particular piece depicts Van Gogh's bedroom in Arles, France, with its distinctive furnishings and vibrant colors. The skewed perspective and bold brushwork reflect Van Gogh's emotional and psychological state during his time in Arles, emphasizing his longing for a place of peace and solitude.");

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArtistId", "CreationDate", "Description", "Dimensions", "ImageUrl", "Title" },
                values: new object[] { 1, new DateTime(1889, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Irises is a painting by Vincent van Gogh, notable for its vibrant blue and purple tones. Van Gogh painted this piece while staying at the asylum in Saint-Rémy-de-Provence, where he found solace in the beauty of the irises growing in the garden. The swirling brushstrokes and expressive use of color capture Van Gogh's emotional depth and connection to nature.", "71 cm × 93 cm", "images/artwork/irises.jpg", "Irises" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArtistId", "CreationDate", "Description", "Dimensions", "ImageUrl", "Title" },
                values: new object[] { 1, new DateTime(1889, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self-Portrait with Bandaged Ear is a self-portrait by Vincent van Gogh, painted shortly after he famously cut off part of his own ear. The painting reflects Van Gogh's resilience and introspection during a turbulent period in his life. The bandaged ear and intense gaze convey the artist's emotional turmoil and artistic identity.", "60 cm × 49 cm", "images/artwork/selfportraitbandagedear.jpg", "Self-Portrait with Bandaged Ear" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArtistId", "CreationDate", "Description", "Dimensions", "ImageUrl", "Title" },
                values: new object[] { 1, new DateTime(1890, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wheatfield with Crows is one of Vincent van Gogh's final paintings, completed shortly before his death. The painting depicts a dramatic, stormy sky over a wheatfield with dark, ominous crows flying overhead. The turbulent atmosphere and bold brushstrokes convey Van Gogh's emotional turmoil and his fascination with the contrasts of life and death.", "50 cm × 103 cm", "images/artwork/wheatfieldwithcrows.jpg", "Wheatfield with Crows" });

            migrationBuilder.InsertData(
                table: "Artworks",
                columns: new[] { "Id", "ArtistId", "CreationDate", "Description", "Dimensions", "ImageUrl", "Medium", "Title" },
                values: new object[,]
                {
                    { 7, 2, new DateTime(1642, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Night Watch is one of the most famous paintings by Rembrandt van Rijn. Also known as The Militia Company of Captain Frans Banning Cocq, the painting depicts a group of city guards preparing for a march. Rembrandt's use of light and shadow creates a dynamic composition, emphasizing movement and individual character among the figures.", "363 cm × 437 cm", "images/artwork/nightwatch.jpg", "Oil on canvas", "The Night Watch" },
                    { 8, 2, new DateTime(1632, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Anatomy Lesson of Dr. Nicolaes Tulp is a group portrait painted by Rembrandt van Rijn. It depicts Dr. Tulp demonstrating a dissection to medical professionals. Rembrandt's meticulous attention to detail and the dramatic use of light and shadow highlight the scientific and human drama of the scene, making it a masterpiece of Baroque art.", "169.5 cm × 216.5 cm", "images/artwork/anatomylesson.jpg", "Oil on canvas", "The Anatomy Lesson of Dr. Nicolaes Tulp" },
                    { 9, 2, new DateTime(1665, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self-Portrait with Two Circles is a notable self-portrait by Rembrandt van Rijn. The circles in the background have been interpreted in various ways, from symbols of artistic perfection to religious and philosophical meanings. Rembrandt's skillful portrayal of himself reflects his introspective nature and mastery of chiaroscuro.", "114.3 cm × 94 cm", "images/artwork/selfportrait.jpg", "Oil on canvas", "Self-Portrait with Two Circles" },
                    { 10, 2, new DateTime(1667, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Jewish Bride is a portrait painting by Rembrandt van Rijn. Also known as Isaac and Rebecca, the painting depicts a tender moment between a Jewish groom and his bride. Rembrandt's sensitive portrayal captures the emotional intimacy and dignity of the couple, making it one of his most renowned works.", "121.5 cm × 166.5 cm", "images/artwork/jewishbride.jpg", "Oil on canvas", "The Jewish Bride" },
                    { 11, 2, new DateTime(1633, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Storm on the Sea of Galilee is a dramatic painting by Rembrandt van Rijn. It depicts the biblical scene of Jesus calming the storm on the Sea of Galilee. Rembrandt's use of light and shadow intensifies the chaos of the storm and the calm authority of Jesus, capturing both the physical and spiritual dimensions of the event.", "160 cm × 128 cm", "images/artwork/stormontheseaofgalilee.jpg", "Oil on canvas", "The Storm on the Sea of Galilee" },
                    { 12, 2, new DateTime(1662, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Syndics of the Drapers' Guild is a group portrait by Rembrandt van Rijn. Commissioned by the cloth merchants' guild in Amsterdam, the painting depicts five syndics inspecting cloth samples. Rembrandt's meticulous attention to detail and the dignified portrayal of the subjects exemplify his mastery of portraiture and narrative composition.", "191.5 cm × 279 cm", "images/artwork/syndicsofthedrapersguild.jpg", "Oil on canvas", "The Syndics of the Drapers' Guild" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Starry Night is one of the most recognized pieces of art in the world. It depicts the view from the east-facing window of his asylum room at Saint-Rémy-de-Provence, just before sunrise, with the addition of an ideal village. The swirling patterns in the sky, the glowing moon and stars, and the sleepy village below create a dynamic and captivating scene that exemplifies his unique style. This painting captures the turbulence and beauty of the night sky, evoking deep emotions and awe.");

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Sunflowers is a series of paintings that are among the most famous works of Vincent van Gogh. These paintings were created to decorate the room of his friend and fellow artist, Paul Gauguin. The bright and vivid yellows, combined with the dynamic brushstrokes, capture the essence of the flowers in various stages of life, from full bloom to withering. The series reflects Van Gogh's fascination with the beauty of nature and his innovative approach to color and composition.");

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "The Bedroom is one of Vincent van Gogh's best-known works. It depicts his own bedroom in Arles, France, with bright and bold colors intended to express absolute 'rest' or 'sleep.' The skewed perspective, the vibrant palette, and the simplicity of the room's furnishings convey a sense of tranquility and personal space. This painting reflects his longing for a place of comfort and refuge, and its intimate nature makes it a touching piece of his collection.");

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArtistId", "CreationDate", "Description", "Dimensions", "ImageUrl", "Title" },
                values: new object[] { 2, new DateTime(1642, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Night Watch is one of the most famous Dutch Golden Age paintings. It depicts a group of city guards moving out, led by Captain Frans Banning Cocq and his lieutenant, Willem van Ruytenburch. The painting is renowned for its colossal size, dramatic use of light and shadow (tenebrism), and the perception of motion in what would have traditionally been a static military group portrait. The intricate details, such as the expressions of the guards, the play of light, and the overall composition, draw viewers into the dynamic scene.", "363 cm × 437 cm", "images/artwork/nightwatch.jpg", "The Night Watch" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArtistId", "CreationDate", "Description", "Dimensions", "ImageUrl", "Title" },
                values: new object[] { 2, new DateTime(1632, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Anatomy Lesson of Dr. Nicolaes Tulp is a group portrait of Dr. Tulp and several other Amsterdam surgeons. It captures a public dissection, a common practice for medical education at the time. The painting stands out for its realistic portrayal of the human anatomy and the lifelike depiction of the surgeons' faces. The lighting highlights the central figures, creating a stark contrast with the dark background, which enhances the dramatic effect. This work is a prime example of Rembrandt's skill in rendering texture, expression, and atmosphere.", "169.5 cm × 216.5 cm", "images/artwork/anatomylesson.jpg", "The Anatomy Lesson of Dr. Nicolaes Tulp" });

            migrationBuilder.UpdateData(
                table: "Artworks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArtistId", "CreationDate", "Description", "Dimensions", "ImageUrl", "Title" },
                values: new object[] { 2, new DateTime(1665, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self-Portrait with Two Circles is a powerful self-portrait that showcases Rembrandt's mastery of chiaroscuro and his deep understanding of human emotion. In this painting, Rembrandt presents himself as an older man, holding his tools and standing confidently in front of two mysterious circles. The circles have been interpreted in various ways, but they add an element of intrigue to the composition. The detailed rendering of his face and the rich textures of his clothing reflect his introspective and honest approach to self-portraiture.", "114.3 cm × 94 cm", "images/artwork/selfportrait.jpg", "Self-Portrait with Two Circles" });
        }
    }
}
