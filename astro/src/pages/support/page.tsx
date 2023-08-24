import { baseUrl } from "../../helper";
import Post from "../../components/post.tsx";
import { useState } from "react";

const supportResponse = await fetch(baseUrl + "/posts?categories=3");
const allPosts = await supportResponse.json();

function SupportPage() {
  const [searchQuery, setSearchQuery] = useState("");

  // Filter posts based on search query
  const filteredPosts = allPosts.filter((post) =>
    post.title.rendered.toLowerCase().includes(searchQuery.toLowerCase())
  );

  return (
    <>
      <div className="my-3 flex flex-col items-center justify-center gap-3 mobile:flex-row">
        <span className="text-lg text-pri">Search support post</span>
        <input
          className="rounded-md border-[1px] border-accent p-3"
          type="text"
          value={searchQuery}
          onChange={(e) => setSearchQuery(e.target.value)}
        />
      </div>
      <div className="flex flex-col gap-3">
        {filteredPosts.length === 0 ? (
          <p className="text-pri">No matching posts found.</p>
        ) : (
          filteredPosts.map((post) => (
            <Post
              key={post.id}
              title={post.title.rendered}
              id={post.id}
              excerpt={post.excerpt.rendered}
              image={post.x_featured_media_original}
              type="support"
            />
          ))
        )}
      </div>
    </>
  );
}

export default SupportPage;
