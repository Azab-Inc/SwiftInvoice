import React from "react";

type Props = {
  type: string;
  id: number;
  title: string;
  excerpt: string;
  image: string;
};

const Post: React.FC<Props> = ({ type, id, title, excerpt, image }) => {
  return (
    <a
      href={`/${type}/${id}`}
      className="flex flex-col gap-3 rounded-md border-2 p-3 mobile:flex-row "
    >
      <div className="flex w-full flex-col justify-center gap-1 mobile:w-2/3">
        <h3 className="font-bold text-pri">{title}</h3>
        <div dangerouslySetInnerHTML={{ __html: excerpt }} />
        <span className="text-pri">
          Read more{" "}
          <i className="fa-solid fa-arrow-up-right-from-square text-pri"></i>
        </span>
      </div>
      <img className="w-full mobile:w-1/3" src={image} alt={title} />
    </a>
  );
};

export default Post;
